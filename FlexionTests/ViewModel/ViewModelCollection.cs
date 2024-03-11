using Xunit;

namespace FlexionTests.ViewModel;

[CollectionDefinition("SettingsCollection")]
public class ViewModelCollection : ICollectionFixture<ViewModelTests>
{
    // This class is empty, but necessary to define the test collection.
    // The collection is used to make the test for the ViewModel one after the other.
    // If not the Setting/Setting.json file was accessed by multiple process at the same time.
}