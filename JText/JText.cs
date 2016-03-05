using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// #######################################################################################
/// ##  |   
/// ##  |   JTEXT IS AN OPEN SOURCE FREEWARE GNU GPL C# LIBARY - 
/// ##  |   WITH ATTRIBUTION REQUIRED TO USE THE DLL
/// ##  |   THE ATTRIBUTION LINE THAT IS REQUIRED SHOULD BE IN ABOUT AREA OF APPLICATION. - 
/// ##  |     
/// ##  |   ATR-LINE: Justified by JText from Droitech Games - www.droitechgames.com/jtext
/// ##  |   
/// ##  |   JText C# Libary is designed to simplify the process of Justifying Text in C#
/// ##  |   Just one of those inconviences caused by the fact that Microsoft forgets to add
/// ##  |   in a crucial piece of text tools. Text Justification in a Single Development Call.
/// ##  |   
/// ##  |   To make the call to the DLL function simply do the following
/// ##  |                
/// ##  |    1. Combine the Text you wish to Justify;
/// ##  |    
/// ##  |    e.g. string combine = "string 1" + Enviroment.NewLine + Enviroment.NewLine + string2;
/// ##  |    
/// ##  |    2. Add the DLL after Compiling to the References of the Project.
/// ##  |    
/// ##  |    3. Make the Call to a Text Object.
/// ##  |    
/// ##  |    e.g. this.label1.Text = JustifyText.Justify(combine,5);
/// ##  |    
/// ##  |    DLL by Droitech Games
/// ##  |    
/// ##  |    End Comment
/// ##  |                        
/// #######################################################################################
namespace JText
{
    public static class JustifyText
    {
        public static String Justify(String stringText, Int32 count)
        {
            if (count <= 0)
                return stringText;

            Int32 middle = stringText.Length / 2;
            IDictionary<Int32, Int32> spaceOffsetsToParts = new Dictionary<Int32, Int32>();
            String[] parts = stringText.Split(' ');
            for (Int32 partIndex = 0, offset = 0; partIndex < parts.Length; partIndex++)
            {
                spaceOffsetsToParts.Add(offset, partIndex);
                offset += parts[partIndex].Length + 1; // +1 to count space that was removed by Split
            }
            foreach (var pair in spaceOffsetsToParts.OrderBy(entry => Math.Abs(middle - entry.Key)))
            {
                count--;
                if (count < 0)
                    break;
                parts[pair.Value] += ' ';
            }
            return String.Join(" ", parts);
        }
    }
}
