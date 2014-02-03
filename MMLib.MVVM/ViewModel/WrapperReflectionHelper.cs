using MMLib.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using MMLib.Extensions;

namespace MMLib.MVVM.ViewModel
{
    /// <summary>
    /// Class which help with reflection for model helper.
    /// </summary>
    public class WrapperReflectionHelper
    {
        #region Private fields

        private object _model;
        private object _viewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Model, which will be wrapped to viewModel.</param>
        /// <param name="viewModel">ViewModel, which wrapped model.</param>
        public WrapperReflectionHelper(object model, object viewModel)
        {
            Contract.Requires(model != null);
            Contract.Requires(viewModel != null);

            _model = model;
            _viewModel = viewModel;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Wrapped information from model to viewModel.
        /// </summary>       
        public void WrappeModelToViewModel()
        {
            var properties = _model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p =>
            {
                return p.CanRead && p.CanWrite && p.GetCustomAttributes(typeof(NonWrappedAttribute), false).Length == 0;
            });

            foreach (var property in properties)
            {
                _viewModel.SetPropertyValue(property.Name, property.GetValue(_model, null));
            }
        }

        /// <summary>
        /// Save changes to model.
        /// </summary>
        public void SaveChangesToModel()
        {
            var properties = _model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p =>
            {
                return p.CanRead && p.CanWrite && p.GetCustomAttributes(typeof(NonWrappedAttribute), false).Length == 0;
            });

            foreach (var property in properties)
            {
                var viewModelProperty = _viewModel.GetType().GetProperty(property.Name);
                if (viewModelProperty != null)
                {
                    _model.SetPropertyValue(property.Name, viewModelProperty.GetValue(_viewModel, null));
                }
            }
        }

        #endregion
    }
}
