# Weather Data Viewer

Start with v1.0 in Tags.

Demo app showing bad code transitioning to using plugin architecture.

This project is used for the talk "From Bad Code to Plug-In Architecture". It starts with working but bad code. The winform uses data from Weather Underground. 

v1.0 Initial version.

v1.1 Added code for Open Weather Map.

v1.2 Uses Poor Man's IoC for the factory to find classes implementing the IWeatherDataGetter interface. Split out the code for Weather Underground and Open Weather Map to their own files.
