using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day19 : IAdventOfCode
    {
        Dictionary<int, string> rules = new Dictionary<int, string>();
        List<string> messages = new List<string>();
        public void DoTask()
        {
            ReadInput();
            Task1();
        }

        public void ReadInput()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input19.txt";
            var lines = File.ReadLines(fileName).ToArray();
            for (int i = 0; i < lines.Length; i++)
            {
                // rule
                if(lines[i].Contains(":"))
                {
                    int ruleNumber =Convert.ToInt32( lines[i].Split(":")[0]);
                    rules.Add(ruleNumber, lines[i].Split(":")[1].ToString());
                }
                // message
                else if (!string.IsNullOrEmpty( lines[i])) 
                {
                    messages.Add(lines[i]);
                }
            }
        }

        public void mapAllPosibleMessages()
        {
            while (true)
            {
                
            }
        }

        public void Task1()
        {
            string rule0 = rules[0];
        }


        public int Part1(string input)
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input19.txt";
            input = File.ReadAllText(fileName);
            var (rules, messages) = Parse(input);
            return messages.Count(m => rules[0].Matches(m).Any(x => x.IsFullMatch));
        }

        public int Part2(string input)
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input19.txt";
            input = File.ReadAllText(fileName);
            input = input.Replace("8: 42", "8: 42 | 42 8").Replace("11: 42 31", "11: 42 31 | 42 11 31");

            var (rules, messages) = Parse(input);

            return messages.Count(m => rules[0].Matches(m).Any(x => x.IsFullMatch));
        }

        public static (Dictionary<int, Rule> rules, string[] messages) Parse(string input)
        {
            var parts = input.Split(Environment.NewLine + Environment.NewLine);

            var rules = parts[0].Split(Environment.NewLine).Select(Rule.Parse).ToDictionary(r => r.RuleId);

            foreach (var rule in rules.Values)
                rule.Resolve(rules);

            var messages = parts[1].Split(Environment.NewLine);
            return (rules, messages);
        }

        public abstract record Rule(int RuleId)
        {
            public virtual void Resolve(Dictionary<int, Rule> allRules) { }

            public abstract Match[] Matches(string input);

            public static Rule Parse(string input)
            {
                var match = Regex.Match(
                    input, "(?<num>\\d*): (?:(?:\\\"(?<char>.*)\\\")|(?<numlist1>.*) \\| (?<numlist2>.*)|(?<numlist>.*))");

                var ruleId = int.Parse(match.Groups["num"].Value);

                LinkRule ParseLinkRule(string value) => new(ruleId, value.Split(' ').Select(int.Parse).ToArray());


                if (match.Groups["numlist"].Success)
                    return ParseLinkRule(match.Groups["numlist"].Value);

                if (match.Groups["numlist1"].Success && match.Groups["numlist2"].Success)
                    return new CompoundRule(ruleId,
                                            ParseLinkRule(match.Groups["numlist1"].Value),
                                            ParseLinkRule(match.Groups["numlist2"].Value));

                if (match.Groups["char"].Success)
                    return new CharRule(ruleId, match.Groups["char"].Value.Single());

                throw new Exception("Can't parse rule");
            }
        }

        record LinkRule(int RuleId, int[] LinkedRuleNumbers) : Rule(RuleId)
        {
            public Rule[] LinkedRules { get; private set; }

            public override Match[] Matches(string input) =>
                LinkedRules.Aggregate(new[] { new Match(input) },
                                      (acc, rule) => acc.SelectMany(m => rule.Matches(m.Remaining))
                                                        .ToArray());

            public override void Resolve(Dictionary<int, Rule> allRules) =>
                LinkedRules = LinkedRuleNumbers.Select(x => allRules[x]).ToArray();
        }

        record CompoundRule(int RuleId, params Rule[] Rules) : Rule(RuleId)
        {
            public override Match[] Matches(string input) => (
                from rule in Rules
                from match in rule.Matches(input)
                select match
            ).ToArray();

            public override void Resolve(Dictionary<int, Rule> allRules)
            {
                foreach (var rule in Rules)
                    rule.Resolve(allRules);
            }
        }

        record CharRule(int RuleId, char Char) : Rule(RuleId)
        {
            public override Match[] Matches(string input) =>
                input.FirstOrDefault() == Char
                    ? new[] { new Match(input.Substring(1)) }
                    : Array.Empty<Match>();
        }

        public record Match(string Remaining)
        {
            public bool IsFullMatch => string.IsNullOrEmpty(Remaining);
        }
    }
}
