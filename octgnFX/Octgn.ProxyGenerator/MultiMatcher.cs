﻿using Octgn.ProxyGenerator.Definitions;
using Octgn.ProxyGenerator.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Octgn.ProxyGenerator
{
    public class MultiMatcher
    {
        public static CardDefinition GetTemplate(List<CardDefinition> cards, Dictionary<string, string> dict, List<string> matchMapping)
        {
            CardDefinition ret = null;
            foreach (CardDefinition card in cards)
            {
                List<string> values = RemapToList(dict, matchMapping);
                int c = values.Count;
                int i = 1;

                foreach (string value in values)
                {
                    if (MappingMatch(value, card))
                    {
                        i++;
                    }
                }

                if (i == c)
                {
                    return (card);
                }
            }
            return (ret);
        }

        internal static bool MappingMatch(string value, CardDefinition card)
        {
            bool ret = false;

            foreach (string s in card.MultiMatch.MultiMatchMappings)
            {
                if (s == value)
                {
                    return true;
                }
            }

            return (ret);
        }

        internal static List<string> DictToList(Dictionary<string, string> dict)
        {
            List<string> ret = new List<string>();
            foreach (KeyValuePair<string, string> kvi in dict)
            {
                ret.Add(kvi.Value);
            }
            return (ret);
        }

        internal static List<string> RemapToList(Dictionary<string, string> dict, List<string> matchMapping)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> kvi in dict)
            {
                if (matchMapping.Contains(kvi.Key))
                {
                    temp.Add(kvi.Key, kvi.Value);
                }
            }
            return DictToList(temp);
        }
    }
}
