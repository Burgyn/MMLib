using MMLib.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMLib.MVVM.ViewModel
{
    /// <summary>
    /// ViewModel wrapper for model.
    /// </summary>
    /// <typeparam name="TModel">Type of Model.</typeparam>
    public interface IModelWrapperViewModel<TModel> where TModel: IModel
    {
        /// <summary>
        /// Model, which this viewmodel wraped.
        /// </summary>
        TModel Model { get; set; }
    }
}
