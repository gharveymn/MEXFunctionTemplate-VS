﻿using System;
using System.Collections.Generic;
using Microsoft.Win32;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using EnvDTE;

namespace MEXFunctionWizard
{
	public class WizardImplementation : IWizard
	{
		private MatlabRootInputForm.UserInputForm inputForm;
		private string matlabroot;
		private string platform;

		// This method is called before opening any item that
		// has the OpenInEditor attribute.
		public void BeforeOpeningFile(ProjectItem projectItem)
		{
		}

		public void ProjectFinishedGenerating(Project project)
		{
		}

		// This method is only called for item templates,
		// not for project templates.
		public void ProjectItemFinishedGenerating(ProjectItem
			projectItem)
		{
		}

		// This method is called after the project is created.
		public void RunFinished()
		{
		}

		public void RunStarted(object automationObject,
			Dictionary<string, string> replacementsDictionary,
			WizardRunKind runKind, object[] customParams)
		{
			try
			{
				// Display a form to the user. The form collects
				// input for the custom message.
				inputForm = new MatlabRootInputForm.UserInputForm();
				if (inputForm.ShowDialog() != DialogResult.OK)
				{
					// abort
				}

				MatlabRootInputForm.UserInputForm.
				matlabroot = MatlabRootInputForm.UserInputForm.matlabroot;
				platform = MatlabRootInputForm.UserInputForm.platform;

				// Add custom parameters.
				replacementsDictionary.Add("$MATLABROOT$", matlabroot);
				replacementsDictionary.Add("$PLATFORM$", platform);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		// This method is only called for item templates,
		// not for project templates.
		public bool ShouldAddProjectItem(string filePath)
		{
			return true;
		}
	}