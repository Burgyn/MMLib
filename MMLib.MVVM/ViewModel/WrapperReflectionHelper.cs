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
    /// <typeparam name="TModel">Model, which help wrapped.</typeparam>
    public class WrapperReflectionHelper<TModel> where TModel : IModel
    {
        #region Private fields

        private TModel _model;
        private IModelWrapperViewModel<TModel> _viewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">Model, which will be wrapped to viewModel.</param>
        /// <param name="viewModel">ViewModel, which wrapped model.</param>
        public WrapperReflectionHelper(TModel model, IModelWrapperViewModel<TModel> viewModel)
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
            _viewModel.Model = _model;

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
            _viewModel.Model = _model;

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
