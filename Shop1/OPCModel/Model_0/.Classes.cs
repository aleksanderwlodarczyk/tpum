/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;
using DataLayer;

namespace DataLayer
{
    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the IFruit ObjectType.
        /// </summary>
        public const uint IFruit = 3;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the IFruit_Id Variable.
        /// </summary>
        public const uint IFruit_Id = 4;

        /// <summary>
        /// The identifier for the IFruit_Name Variable.
        /// </summary>
        public const uint IFruit_Name = 5;

        /// <summary>
        /// The identifier for the IFruit_Price Variable.
        /// </summary>
        public const uint IFruit_Price = 6;

        /// <summary>
        /// The identifier for the IFruit_Origin Variable.
        /// </summary>
        public const uint IFruit_Origin = 7;

        /// <summary>
        /// The identifier for the IFruit_FruitType Variable.
        /// </summary>
        public const uint IFruit_FruitType = 8;
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the IFruit ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId IFruit = new ExpandedNodeId(DataLayer.ObjectTypes.IFruit, DataLayer.Namespaces.DataLayer);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the IFruit_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId IFruit_Id = new ExpandedNodeId(DataLayer.Variables.IFruit_Id, DataLayer.Namespaces.DataLayer);

        /// <summary>
        /// The identifier for the IFruit_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId IFruit_Name = new ExpandedNodeId(DataLayer.Variables.IFruit_Name, DataLayer.Namespaces.DataLayer);

        /// <summary>
        /// The identifier for the IFruit_Price Variable.
        /// </summary>
        public static readonly ExpandedNodeId IFruit_Price = new ExpandedNodeId(DataLayer.Variables.IFruit_Price, DataLayer.Namespaces.DataLayer);

        /// <summary>
        /// The identifier for the IFruit_Origin Variable.
        /// </summary>
        public static readonly ExpandedNodeId IFruit_Origin = new ExpandedNodeId(DataLayer.Variables.IFruit_Origin, DataLayer.Namespaces.DataLayer);

        /// <summary>
        /// The identifier for the IFruit_FruitType Variable.
        /// </summary>
        public static readonly ExpandedNodeId IFruit_FruitType = new ExpandedNodeId(DataLayer.Variables.IFruit_FruitType, DataLayer.Namespaces.DataLayer);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the Fruit component.
        /// </summary>
        public const string Fruit = "Fruit";

        /// <summary>
        /// The BrowseName for the Id component.
        /// </summary>
        public const string Id = "Id";

        /// <summary>
        /// The BrowseName for the Price component.
        /// </summary>
        public const string Price = "Price";

        /// <summary>
        /// The BrowseName for the FruitType component.
        /// </summary>
        public const string FruitType = "FruitType";

        /// <summary>
        /// The BrowseName for the Origin component.
        /// </summary>
        public const string Origin = "Origin";

        /// <summary>
        /// The BrowseName for the Name component.
        /// </summary>
        public const string Name = "Name";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the cas namespace (.NET code namespace is '').
        /// </summary>
        public const string cas = "http://cas.eu/UA/CommServer/";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the DataLayer namespace (.NET code namespace is 'DataLayer').
        /// </summary>
        public const string DataLayer = "http://group13.com/TPUM/Shop1/";
    }
    #endregion

    #region IFruitState Class
    #if (!OPCUA_EXCLUDE_IFruitState)
    /// <summary>
    /// Stores an instance of the IFruit ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class IFruitState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public IFruitState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DataLayer.ObjectTypes.IFruit, DataLayer.Namespaces.DataLayer, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAABwAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvHgAAAGh0dHA6Ly9ncm91cDEzLmNvbS9U" +
           "UFVNL1Nob3AxL/////8EYIAAAQAAAAIADgAAAElGcnVpdEluc3RhbmNlAQIDAAECAwD/////BQAAABVg" +
           "iQoCAAAAAgACAAAASWQBAgQAAC4ARAQAAAAADv////8BAf////8AAAAAFWCJCgIAAAACAAQAAABOYW1l" +
           "AQIFAAAuAEQFAAAAAAz/////AQH/////AAAAABVgiQoCAAAAAgAFAAAAUHJpY2UBAgYAAC4ARAYAAAAA" +
           "Cv////8BAf////8AAAAAFWCJCgIAAAACAAYAAABPcmlnaW4BAgcAAC4ARAcAAAAAG/////8BAf////8A" +
           "AAAAFWCJCgIAAAACAAkAAABGcnVpdFR5cGUBAggAAC4ARAgAAAAAG/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Id Property.
        /// </summary>
        public PropertyState<Guid> Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <summary>
        /// A description for the Name Property.
        /// </summary>
        public PropertyState<string> Name
        {
            get
            {
                return m_name;
            }

            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <summary>
        /// A description for the Price Property.
        /// </summary>
        public PropertyState<float> Price
        {
            get
            {
                return m_price;
            }

            set
            {
                if (!Object.ReferenceEquals(m_price, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_price = value;
            }
        }

        /// <summary>
        /// A description for the Origin Property.
        /// </summary>
        public PropertyState Origin
        {
            get
            {
                return m_origin;
            }

            set
            {
                if (!Object.ReferenceEquals(m_origin, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_origin = value;
            }
        }

        /// <summary>
        /// A description for the FruitType Property.
        /// </summary>
        public PropertyState FruitType
        {
            get
            {
                return m_fruitType;
            }

            set
            {
                if (!Object.ReferenceEquals(m_fruitType, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_fruitType = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_price != null)
            {
                children.Add(m_price);
            }

            if (m_origin != null)
            {
                children.Add(m_origin);
            }

            if (m_fruitType != null)
            {
                children.Add(m_fruitType);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case DataLayer.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new PropertyState<Guid>(this);
                            }
                            else
                            {
                                Id = (PropertyState<Guid>)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case DataLayer.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new PropertyState<string>(this);
                            }
                            else
                            {
                                Name = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case DataLayer.BrowseNames.Price:
                {
                    if (createOrReplace)
                    {
                        if (Price == null)
                        {
                            if (replacement == null)
                            {
                                Price = new PropertyState<float>(this);
                            }
                            else
                            {
                                Price = (PropertyState<float>)replacement;
                            }
                        }
                    }

                    instance = Price;
                    break;
                }

                case DataLayer.BrowseNames.Origin:
                {
                    if (createOrReplace)
                    {
                        if (Origin == null)
                        {
                            if (replacement == null)
                            {
                                Origin = new PropertyState(this);
                            }
                            else
                            {
                                Origin = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = Origin;
                    break;
                }

                case DataLayer.BrowseNames.FruitType:
                {
                    if (createOrReplace)
                    {
                        if (FruitType == null)
                        {
                            if (replacement == null)
                            {
                                FruitType = new PropertyState(this);
                            }
                            else
                            {
                                FruitType = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = FruitType;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<Guid> m_id;
        private PropertyState<string> m_name;
        private PropertyState<float> m_price;
        private PropertyState m_origin;
        private PropertyState m_fruitType;
        #endregion
    }
    #endif
    #endregion
}