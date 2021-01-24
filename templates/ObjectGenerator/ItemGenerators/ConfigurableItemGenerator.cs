using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ClimaControl.Data;
using ClimaControl.UI.Services.Configuration;

namespace ObjectGenerator.ItemGenerators
{
    public class ConfigurableItemGenerator
    {
        private ConfigurableItemNamespaces _namespaces;
        private ConfigurableItemFileNames _fileNames;
        private CodeCompileUnit _itemUnit;
        private CodeCompileUnit _itemViewUnit;
        private CodeCompileUnit _itemViewModelUnit;
        private CodeCompileUnit _itemViewInterfaceUnit;
        private CodeCompileUnit _itemViewModelInterfaceUnit;
        private List<ConfigurableItemProperty> _properties;
        private string _newItemName;
        private string _outputFolder;
        public ConfigurableItemGenerator()
        {
            _fileNames = new ConfigurableItemFileNames();
            _properties = new List<ConfigurableItemProperty>();
            _namespaces = new ConfigurableItemNamespaces();
        }

        public void GenerateCode()
        {
            if(_outputFolder==null||_outputFolder==String.Empty)
                return;
            if (!Directory.Exists(_outputFolder))
                Directory.CreateDirectory(_outputFolder);


            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";

            
            using (StreamWriter sourceWriter = new StreamWriter(Path.Combine(_outputFolder,_fileNames.Item)))
            {
                provider.GenerateCodeFromCompileUnit(
                    _itemUnit, sourceWriter, options);
            }
            using (StreamWriter sourceWriter = new StreamWriter(Path.Combine(_outputFolder, _fileNames.ItemViewInterface)))
            {
                provider.GenerateCodeFromCompileUnit(
                    _itemViewInterfaceUnit, sourceWriter, options);
            }
            using (StreamWriter sourceWriter = new StreamWriter(Path.Combine(_outputFolder, _fileNames.ItemViewModelInterface)))
            {
                provider.GenerateCodeFromCompileUnit(
                    _itemViewModelInterfaceUnit, sourceWriter, options);
            }
            using (StreamWriter sourceWriter = new StreamWriter(Path.Combine(_outputFolder, _fileNames.ItemViewModel)))
            {
                provider.GenerateCodeFromCompileUnit(
                    _itemViewModelUnit, sourceWriter, options);
            }
        }
        public void BuildModel()
        {
            if(_newItemName==null)
                return;


            if (_newItemName.Trim(' ').Length > 0)
            {
                var itemName = _newItemName.Trim(' ');

                //Create item unit;
                _itemUnit = CreateItemUnit();
                _itemViewInterfaceUnit = CreateItemViewInterface();
                _itemViewModelInterfaceUnit = CreateItemViewModelInterface();
                _itemViewModelUnit = CreateItemViewModel();
            }
        }
        public ConfigurableItemNamespaces Namespaces
        {
            get => _namespaces;
            set => _namespaces = value;
        }

        public string NewItemName
        {
            get { return _newItemName; }
            set
            {
                _newItemName = value;
                _fileNames.Item = _newItemName + ".cs";
                _fileNames.ItemView = _newItemName + "View.xaml";
                _fileNames.ItemViewCb = _newItemName + "View.xaml.cs";
                _fileNames.ItemViewModel = _newItemName + "ViewModel.cs";
                _fileNames.ItemViewInterface = "I" + _newItemName + "View.cs";
                _fileNames.ItemViewModelInterface = "I" + _newItemName + "ViewModel.cs";
            }
        }

        public ConfigurableItemFileNames FileNames
        {
            get => _fileNames;
            set => _fileNames = value;
        }

        public List<ConfigurableItemProperty> Properties
        {
            get => _properties;
            set => _properties = value;
        }

        public string OutputFolder
        {
            get => _outputFolder;
            set => _outputFolder = value;
        }

        private CodeCompileUnit CreateItemUnit()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            
            CodeNamespace globalNs = new CodeNamespace();
            globalNs.Imports.Add(new CodeNamespaceImport(Namespaces.Data));

            CodeNamespace itemNs = new CodeNamespace(Namespaces.Item);
            

            CodeTypeDeclaration targetClass = new CodeTypeDeclaration(_newItemName);
            targetClass.IsClass = true;
            targetClass.TypeAttributes = TypeAttributes.Public;
            targetClass.BaseTypes.Add(new CodeTypeReference(new CodeTypeParameter("ConfigItem")));

            foreach (var property in _properties)
            {
                CreateItemProperty(targetClass, property.PropertyName, property.PropertyType);
               
            }

            itemNs.Types.Add(targetClass);
            unit.Namespaces.Add(globalNs);
            unit.Namespaces.Add(itemNs);
            //targetClass.

            return unit;
        }

        private CodeCompileUnit CreateItemViewInterface()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            
            CodeNamespace globalNs = new CodeNamespace();
            globalNs.Imports.Add(new CodeNamespaceImport(Namespaces.Views));

            CodeNamespace itemNs = new CodeNamespace(Namespaces.ItemViewInterface);

            CodeTypeDeclaration viewInterface = new CodeTypeDeclaration("I"+_newItemName+"View");
            viewInterface.IsInterface = true;
            viewInterface.TypeAttributes = TypeAttributes.Public;
            viewInterface.BaseTypes.Add(new CodeTypeReference(new CodeTypeParameter("IView")));

            itemNs.Types.Add(viewInterface);

            unit.Namespaces.Add(globalNs);
            unit.Namespaces.Add(itemNs);
            return unit;
        }

        private CodeCompileUnit CreateItemViewModelInterface()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace globalNs = new CodeNamespace();
            globalNs.Imports.Add(new CodeNamespaceImport(Namespaces.ViewModels));

            CodeNamespace itemNs = new CodeNamespace(Namespaces.ItemViewModelInterface);
            
            CodeTypeDeclaration vmInterface=new CodeTypeDeclaration("I"+_newItemName+"ViewModel");
            vmInterface.IsClass = false;
            vmInterface.IsInterface = true;
            vmInterface.TypeAttributes = TypeAttributes.Public |TypeAttributes.Interface;
            vmInterface.BaseTypes.Add(new CodeTypeReference(new CodeTypeParameter("IViewModel")));

            foreach (var property in Properties)
            {
                CodeMemberProperty p = new CodeMemberProperty();
                p.Name = property.PropertyName;
                p.HasSet = true;
                p.HasGet = true;
                p.Type = new CodeTypeReference(new CodeTypeParameter(property.PropertyType));
                vmInterface.Members.Add(p);

            }

            itemNs.Types.Add(vmInterface);

            unit.Namespaces.Add(globalNs);
            unit.Namespaces.Add(itemNs);
            return unit;
        }

        private CodeCompileUnit CreateItemViewModel()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace globalNs = new CodeNamespace();
            globalNs.Imports.Add(new CodeNamespaceImport(Namespaces.ItemViewModelInterface));
            unit.Namespaces.Add(globalNs);
            CodeNamespace itemNs = new CodeNamespace(Namespaces.ItemViewModel);

            CodeTypeDeclaration viewmodel = new CodeTypeDeclaration(_newItemName+"ViewModel");
            viewmodel.IsClass = true;
            viewmodel.TypeAttributes = TypeAttributes.Public;
            viewmodel.BaseTypes.Add(new CodeTypeReference(new CodeTypeParameter("ObservableObject")));
            viewmodel.BaseTypes.Add(new CodeTypeReference(new CodeTypeParameter("I"+_newItemName+"ViewModel")));
            
            //IConfigurationService field declaration
            CodeMemberField configServiceField = new CodeMemberField(new CodeTypeReference(new CodeTypeParameter("IConfigurationService")),"_configService");
            configServiceField.Attributes = MemberAttributes.Private | MemberAttributes.Final;
            viewmodel.Members.Add(configServiceField);

            //ViewMoel Constructor declaratio
            CodeConstructor vmCtor = new CodeConstructor();
            vmCtor.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(new CodeTypeParameter("IConfigurationService")), "configService"));
            vmCtor.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            CodeFieldReferenceExpression modelRef = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "_configService");
            CodeAssignStatement modelAssign = new CodeAssignStatement(modelRef,new CodeArgumentReferenceExpression("configService"));
            vmCtor.Statements.Add(modelAssign);

            viewmodel.Members.Add(vmCtor);
            //ViewModel Propertyies declaration
            foreach (var property in Properties)
            {
                CodeMemberField propField = new CodeMemberField(
                    property.PropertyType, "_" + property.PropertyName.ToLower());
                propField.Attributes = MemberAttributes.Private | MemberAttributes.Final;
                viewmodel.Members.Add(propField);

                CodeMemberProperty p = new CodeMemberProperty();
                p.Attributes = MemberAttributes.Public;
                p.Type=new CodeTypeReference(new CodeTypeParameter(property.PropertyType));
                p.Name = property.PropertyName;
                p.HasGet = true;
                p.HasSet = true;
                p.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),
                        "_" + property.PropertyName.ToLower())));

                

                CodeDirectionExpression param1 = new CodeDirectionExpression(FieldDirection.Ref, new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), propField.Name));
                CodeDirectionExpression param2 = new CodeDirectionExpression(FieldDirection.In, new CodePropertySetValueReferenceExpression());
                CodeMethodInvokeExpression setStatement = new CodeMethodInvokeExpression(
                    new CodeThisReferenceExpression(), "Update",param1,param2);


                p.SetStatements.Add(setStatement);
                viewmodel.Members.Add(p);
            }

            itemNs.Types.Add(viewmodel);

            unit.Namespaces.Add(itemNs);

            return unit;
        }
        private CodeMemberField CreatePropertyField( string name, string type)
        {
            return new CodeMemberField(type,name);
        }
        private void CreateItemProperty(CodeTypeDeclaration targetClass, string name, string type)
        {
            var member = new CodeMemberProperty();
            member.Attributes = MemberAttributes.Public;
            member.Name = name;
            member.Type = new CodeTypeReference(new CodeTypeParameter(type));
            member.HasGet = true;
            member.HasSet = true;

            var field = CreatePropertyField("_" + name.ToLower(), type);
            field.Attributes = MemberAttributes.Private;
            targetClass.Members.Add(field);

            member.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), field.Name)));

            member.SetStatements.Add(new CodeAssignStatement(
                new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), field.Name), new CodePropertySetValueReferenceExpression()));
            targetClass.Members.Add(member);
        }
    }
}