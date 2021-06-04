using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeUltimate
{
    class Day4 : IAdventOfCode
    {
        public void DoTask()
        {
            // i get 244, but right answer is 245 hmmmm
            var allPersonalData = GetPersonalDataTab();
            int validPersonalData = 0;
            for (int i = 0; i < allPersonalData.Length; i++)
            {
                PersonalData checkPersonalData = allPersonalData[i];
                if (ValidationRule(checkPersonalData))
                {
                    validPersonalData++;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine(validPersonalData);
        }
        public bool ValidationRule(PersonalData personalData)
        {
            if (string.IsNullOrWhiteSpace(personalData.BirthYear))
            {
                return false;
            }
            else
            {
                int BirthYear = Convert.ToInt32(personalData.BirthYear);
                if (BirthYear < 1920 || BirthYear > 2002)
                    return false;
            }

            if (string.IsNullOrWhiteSpace(personalData.IssueYear))
            {
                return false;
            }
            else
            {
                int IssueYear = Convert.ToInt32(personalData.IssueYear);
                if (IssueYear < 2010 || IssueYear > 2020)
                    return false;
            }

            if (string.IsNullOrWhiteSpace(personalData.ExpirationYear))
            {
                return false;
            }
            else
            {
                int expirationYear = Convert.ToInt32(personalData.ExpirationYear);
                if (expirationYear < 2020 || expirationYear > 2030)
                    return false;
            }

            if (string.IsNullOrWhiteSpace(personalData.Height))
            {
                return false;
            }
            else
            {
                //cm
                if (personalData.Height.Contains("cm") && int.TryParse(new string(personalData.Height.TakeWhile(char.IsDigit).ToArray()), out var height))
                {
                    if (height < 150 || height > 193)
                    {
                        return false;
                    }
                }

                // in
                else if (personalData.Height.Contains("in") && int.TryParse(new string(personalData.Height.TakeWhile(char.IsDigit).ToArray()), out var anotherHeight))
                {
                    if (anotherHeight < 59 || anotherHeight > 76)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(personalData.HairColor))
            {
                return false;
            }
            else
            {
                if (personalData.HairColor[0] != '#' || personalData.HairColor.Length != 7)
                {
                    return false;
                }
                else
                {
                    char[] validNumbersChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
                    foreach (var item in personalData.HairColor.Skip(1))
                    {
                        if (!validNumbersChars.Contains(item))
                        {
                            return false;
                        }

                    }
                }
            }

            if (string.IsNullOrWhiteSpace(personalData.EyeColor))
            {
                return false;
            }
            else
            {

                if (personalData.EyeColor != "amb" &&
                    personalData.EyeColor != "blu" &&
                    personalData.EyeColor != "brn" &&
                    personalData.EyeColor != "gry" &&
                    personalData.EyeColor != "grn" &&
                    personalData.EyeColor != "hzl" &&
                    personalData.EyeColor != "oth")
                {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(personalData.PassportId))
            {
                return false;
            }
            else
            {
                if (personalData.PassportId.Length != 9 || personalData.PassportId.Any(c => !char.IsDigit(c)))
                {
                    return false;
                }

                {
                    bool noMoreZeros = false;
                    for (int i = 0; i < 9; i++)
                    {
                        if (!char.IsDigit(personalData.PassportId[i]))
                        {
                            return false;
                        }
                        //if (noMoreZeros && personalData.PassportId[i] == '0')
                        //{
                        //    return false;
                        //}
                        //if (personalData.PassportId[i] != '0')
                        //{
                        //    noMoreZeros = true;

                        //}

                    }
                }
            }

            return true;
        }
        public PersonalData[] GetPersonalDataTab()
        {
            string fileName = "G:\\Advent Of Code 2020\\AdventeOfCodeUltimate\\AdventeOfCodeUltimate\\Input4.txt";
            string[] lines = File.ReadLines(fileName).ToArray();
            List<PersonalData> personalDatas = new List<PersonalData>();
            PersonalData personalData = new PersonalData();
            for (int i = 0; i < lines.Length; i++)
            {

                if (!string.IsNullOrWhiteSpace(lines[i]))
                {
                    var KeyValues = lines[i].Split(" ", StringSplitOptions.TrimEntries);
                    for (int j = 0; j < KeyValues.Length; j++)
                    {
                        var keyValuesSpllited = KeyValues[j].Split(":", StringSplitOptions.RemoveEmptyEntries);
                        switch (keyValuesSpllited[0])
                        {
                            case "byr": // Birth Year
                                personalData.BirthYear = keyValuesSpllited[1];
                                break;
                            case "iyr": // Issue Year
                                personalData.IssueYear = keyValuesSpllited[1];
                                break;
                            case "eyr": // Expiration Year
                                personalData.ExpirationYear = keyValuesSpllited[1];
                                break;
                            case "hgt": // Hair Color
                                personalData.Height = keyValuesSpllited[1];
                                break;
                            case "hcl": // Eye Color
                                personalData.HairColor = keyValuesSpllited[1];
                                break;
                            case "ecl": // Eye Color
                                personalData.EyeColor = keyValuesSpllited[1];
                                break;
                            case "pid": // Passport ID
                                personalData.PassportId = keyValuesSpllited[1];
                                break;
                            case "cid": // Country ID
                                personalData.CountryId = keyValuesSpllited[1];
                                break;
                            default:
                                int a = 4;
                                break;
                        }

                    }

                }
                else
                {
                    personalDatas.Add(personalData);
                    personalData = new PersonalData();
                    continue;

                }
            }
            return personalDatas.ToArray();
        }
    }


    public class PersonalData
    {
        public string BirthYear = null;
        public string IssueYear = null;
        public string ExpirationYear = null;
        public string Height = null;
        public string HairColor = null;
        public string EyeColor = null;
        public string PassportId = null;
        public string CountryId = null;

    }
}
