﻿using System.ComponentModel.Composition;
using ADOTabular;
using Caliburn.Micro;

namespace DaxStudio.UI.ViewModels
{
    [Export]
    public class FunctionPaneViewModel:ToolPaneBaseViewModel
    {
        public FunctionPaneViewModel(ADOTabularConnection connection, IEventAggregator eventAggregator) : base(connection, eventAggregator)
        {
            Connection = connection;
            EventAggregator = eventAggregator; 
        }

        public ADOTabularFunctionGroupCollection FunctionGroups{
            get { return Connection == null ? null : Connection.FunctionGroups; }
            
        }

        protected override void OnConnectionChanged()
        {
            base.OnConnectionChanged();
            NotifyOfPropertyChange(()=> FunctionGroups);
        }

        public override string DefaultDockingPane
        {
            get { return "DockLeft"; }
            set { base.DefaultDockingPane = value; }
        }
        public override string Title
        {
            get { return "Functions"; }
            set { base.Title = value; }
        }
    }
}
