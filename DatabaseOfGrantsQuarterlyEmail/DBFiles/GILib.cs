using System;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;

namespace GrantsIdentification
{
    public class GILib
    {
        public void LogIt(string txt, bool ShowMsgBox = false, string MsgTitle = "", GIDB.SQLParamCollection Params = null)
        {

            // Dim mbs As Integer = IIf(MessageBoxStyle = -1, MsgBoxStyle.Critical, MessageBoxStyle)

            try
            {
                // ===== from - http://www.dotnet247.com/247reference/msgs/58/291207.aspx
                string s = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                s += ".config";

                // ### We need to fix this path
                Uri uu = new Uri(s);
                string strFileName = uu.LocalPath;
                // ===== 

                string LogPath = strFileName + "_PIErrorLog.txt";

                StreamWriter objReader = new StreamWriter(LogPath, true);
                string ErrMsg = "";

                objReader.Write(Constants.vbCrLf + Constants.vbCrLf + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " - " + txt + Constants.vbCrLf);

                // Get the calling method's name
                StackTrace stackTrace = new StackTrace();
                StackFrame StackFrame = stackTrace.GetFrame(1);
                System.Reflection.MethodBase methodBase = StackFrame.GetMethod();
                objReader.Write("Method Name: " + methodBase.Name + Constants.vbCrLf);

                // Get the caller of the calling method
                if (stackTrace.FrameCount > 2)
                {
                    StackFrame = stackTrace.GetFrame(2);
                    methodBase = StackFrame.GetMethod();
                    objReader.Write("Method Name: " + methodBase.Name + Constants.vbCrLf);
                }

                if ((Params != null))
                {
                    foreach (SqlParameter p in Params.ParamCollection)
                        ErrMsg += Constants.vbCrLf + Constants.vbTab + "Name: " + Constants.vbTab + p.ParameterName + Constants.vbTab + "Value: " + Constants.vbTab + p.Value;
                    objReader.Write(ErrMsg);
                }

                objReader.Close();
            }
            catch
            {
            }

            if ((ShowMsgBox))
                Interaction.MsgBox(txt, MsgBoxStyle.Critical, MsgTitle);
        }

        //public static string ConvertDirectionToSql(string sortExpr, SortDirection sortDir, string LastSortExpr, string LastSortDir)
        //{
        //    string strNewSortDirection = string.Empty;
            
        //    string strExpression = sortExpr;
        //    string strDirection = (sortDir == SortDirection.Ascending) ? "ASC" : "DESC";
        //    string strLastExpression = LastSortExpr;
        //    string strLastDirection = LastSortDir;
            
        //    switch (strDirection)
        //    {
        //        case "ASC":
        //            {
        //                if (strExpression == strLastExpression)
        //                {
        //                    if (strLastDirection == "Asc")
        //                        strNewSortDirection = "Desc";
        //                    else
        //                        strNewSortDirection = "Asc";
        //                }
        //                else
        //                    strNewSortDirection = "Asc";
        //                break;
        //            }

        //        case "DESC":
        //            {
        //                if (strExpression == strLastExpression)
        //                {
        //                    if (strLastDirection == "Desc")
        //                        strNewSortDirection = "Asc";
        //                    else
        //                        strNewSortDirection = "Desc";
        //                }
        //                else
        //                    strNewSortDirection = "Desc";
        //                break;
        //            }
        //    }

        //    return strNewSortDirection;
        //}
    }
}