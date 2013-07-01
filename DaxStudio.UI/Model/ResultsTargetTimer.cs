﻿using System;
using System.ComponentModel.Composition;
using DaxStudio.UI.ViewModels;

namespace DaxStudio.UI.Model
{
    // This Results Target discards the returned dataset
    // this is primarily aimed at scenarios like performance tuning
    // where you are interested in the speed of the raw query and
    // do not want to be influenced by the time taken to render
    // the results.
    [Export(typeof(IResultsTarget))]
    public class ResultTargetTimer :  IResultsTarget
    {
        public string Name {get { return "Timer"; } }
        public string Group {get { return "Standard"; } }

        public void OutputResults(IQueryRunner runner)
        {
            try
            {
                runner.OutputMessage("Query Started");
                var start = DateTime.Now;
                var dq = runner.QueryText;
                var res = runner.ExecuteQuery(dq);
                var end = DateTime.Now;
                var durationMs = (end - start).TotalMilliseconds;
                runner.OutputMessage(string.Format("Query Completed ({0} row{1} returned)", res.Rows.Count, res.Rows.Count == 1 ? "" : "s"), durationMs);
            }
            catch (Exception ex)
            {
                runner.ActivateOutput();
                runner.OutputError(ex.Message);
            }
        }

    }
}
