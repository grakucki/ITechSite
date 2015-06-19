using System.IO;
using System.Runtime.Serialization;
using System.Xml;
namespace InstrukcjeProdukcyjne.Properties {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        
        public Settings() {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
             this.SettingsSaving += this.SettingsSavingEventHandler;
             this.SettingsLoaded += this.SettingsLoadedEventHandler;
            //
        }

        private void SettingsLoadedEventHandler(object sender, System.Configuration.SettingsLoadedEventArgs e)
        {
            var LocalDirPath = (string) Properties["LocalDir"].DefaultValue;

            ConfigPath = ITechSettings.GetFileConfigPath(LocalDirPath);
            PathExist(ConfigPath);

            App = ITechInstrukcjeModel.XmlStore.LoadFromXmlOrDefault<ITechSettings>(ConfigPath);
            App.ApplyDefaultIfEmpty();
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {

            ITechInstrukcjeModel.XmlStore.SaveToXml(ConfigPath, App);
        }

        ///// <summary>
        ///// use [DataContract] and [DataMember] in class to save
        ///// </summary>
        ///// <param name="objectToSerialize">obiekkt do serializacji</param>
        ///// <param name="filename"> pełna nazwa pliku </param>
        //private void SaveToXml(object objectToSerialize, string filename)
        //{
        //    PathExist(filename);

        //    using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(XmlWriter.Create(filename)))
        //    {
        //        //System.Runtime.Serialization.
        //        DataContractSerializer serializer = new DataContractSerializer(objectToSerialize.GetType());
        //        serializer.WriteObject(writer, objectToSerialize);
        //    }
        //}




        private void PathExist(string filename)
        {
            var x = Path.GetDirectoryName(filename);
            if (!Directory.Exists(x))
                StartupApp.CreateWorkDirektory(x);

        }


        public string ConfigPath { get; set; }
        public ITechSettings App { get; set; }
    }

}
