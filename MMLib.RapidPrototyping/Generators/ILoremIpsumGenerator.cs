using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLib.RapidPrototyping.Generators
{
    /// <summary>
    /// Interface or lorem ipsum generator.
    /// </summary>
    public interface ILoremIpsumGenerator
    {
        /// <summary>
        /// Generate next lorem ipsum paragraphs.
        /// </summary>
        /// <param name="paragraphsCount">Paragraphs count. Rather then 0.</param>
        /// <returns>
        /// Lorem ipsum paragraphs separate by Enviroment.NewLine.
        /// </returns>
        string Next(int paragraphsCount);


        /// <summary>
        /// Generate next lorem ipsum paragraphs.
        /// </summary>
        /// <param name="paragraphsCount">Paragraphs count. Rather then 0.</param>
        /// <param name="maxSentencesInParagraph">Max count of sentences in paragraphs. Rather then 0.</param>
        /// <returns>
        /// Lorem ipsum paragraphs separate by Enviroment.NewLine.
        /// </returns>
        string Next(int paragraphsCount, int maxSentencesInParagraph);
    }
}
