using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using AxWMPLib;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Solution
{
	public class NodeSorter : IComparer
	{
		
		private static Regex sRegex;
		static NodeSorter()
		{
			sRegex = new Regex("[\\W\\.]*([\\w-[\\d]]+|[\\d]+)", RegexOptions.Compiled);
		}
		// Compare the length of the strings, or the strings
		// themselves, if they are the same length.
		public int Compare(object x, object y)
			{
			TreeNode tx = (TreeNode) x;
			TreeNode ty = (TreeNode) y;
			
			// optimization: if left and right are the same object, then they compare as the same
			if (tx.Text == ty.Text)
			{
				return 0;
			}
			
			MatchCollection leftmatches = sRegex.Matches(tx.Text);
			MatchCollection rightmatches = sRegex.Matches(ty.Text);
			
			IEnumerator enrm = rightmatches.GetEnumerator();
			foreach (Match lm in leftmatches)
			{
				if (! enrm.MoveNext())
				{
					// the right-hand string ran out first, so is considered "less-than" the left
					return 1;
				}
				Match rm = enrm.Current as Match;
				
				int tokenresult = CompareTokens(CapturedStringFromMatch(lm), CapturedStringFromMatch(rm));
				if (tokenresult != 0)
				{
					return tokenresult;
				}
			}
			
			// the lefthand matches are exhausted;
			// if there is more, then left was shorter, ie, lessthan
			// if there's no more left in the righthand, then they were all equal
			return ((enrm.MoveNext()) ? - 1 : 0);
			
		}
		
		private string CapturedStringFromMatch(Match match)
		{
            //System.Diagnostics.Debug.Assert(match.Captures.Count == 1);
			return match.Captures[0].Value;
		}

        private int CompareTokens(string left, string right)
        {
            double leftval;
            double rightval;
            bool leftisnum;
            bool rightisnum;

            leftisnum = double.TryParse(left, out leftval);
            rightisnum = double.TryParse(right, out rightval);

            // numbers always sort in front of text

            if (leftisnum)
            {
                if (!rightisnum)
                {
                    return -1;
                }
                // they're both numeric
                if (leftval < rightval)
                {
                    return -1;
                }
                if (rightval < leftval)
                {
                    return 1;
                }

                // if values are same, this might be due to leading 0s.
                // Assuming this, the longest string would indicate more leading 0s
                // which should be considered to have lower value
                return Math.Sign(right.Length - left.Length);
            }

            // if the right's numeric but left isn't, then the right one must sort first
            if (rightisnum)
            {
                return 1;
            }

            // otherwise do a straight text comparison
            return left.CompareTo(right);
        }
		
	}
	
	
}
