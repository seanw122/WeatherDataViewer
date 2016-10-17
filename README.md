# Weather Data Viewer

Start with v1.0 in Tags.

Demo app showing bad code transitioning to using plugin architecture.

This project is used for the talk "From Bad Code to Plug-In Architecture". It starts with working but bad code. The winform uses data from Weather Underground. 

v1.0 Initial version.

v1.1 Added code for Open Weather Map.

v1.2 Uses Poor Man's IoC for the factory to find classes implementing the IWeatherDataGetter interface. Split out the code for Weather Underground and Open Weather Map to their own files.

v1.3 Split Weather Underground and Open Weather Map into separate projects. Their reference point to the main project to use IWeatherDataGetter interface.

v1.4 Winform uses BackgroundWorker class to make UI responsive. Common project is created to house the interfaces the plugins implement. All projects have a project level reference to Common. Plugins are found using MEF.
