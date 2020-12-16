using System;
using System.Collections.Generic;
using System.Text;

namespace server
{
    public class DataHandler
    {
        char splitter = '/';

        /// <summary>
        /// Converts a string with data sepperated by a '/' to a list of strings.
        /// </summary>
        /// <param name="dataString">The string with data</param>
        /// <returns>List with all seperated data</returns>
        public List<string> DataToList(string dataString)
        {
            List<string> dataList = new List<string>();
            string memoryString = "";
            

            foreach(char a in dataString)
            {
                if (a == splitter)
                {
                    dataList.Add(memoryString);
                    memoryString = "";
                }
                else
                {
                    memoryString += a;
                }
            }

            dataList.Add(memoryString);

            return dataList;
        }

        /// <summary>
        /// Converts a list of strings to a string with all elements seperated by a '/'
        /// </summary>
        /// <param name="dataList">The list containing data</param>
        /// <returns>A string with data, seperated by a '/'</returns>
        public string ListToData(List<string> dataList)
        {
            string totalString = "";

            foreach(string element in dataList)
            {
                totalString += element;
                totalString += splitter;
            }

            return totalString;
        }
    }
}
