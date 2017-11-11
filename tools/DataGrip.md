# DataGrip

## How To Export/Import A Data Source From DataGrip?
> It is possible! You need to share a project with your friend — all you do in DataGrip is in the context of a project. If you did not create a new one, everything is under the default project.
> File - open Recent - manage projects - go to project path
> paste project config
> In my case, I wanted to move project level data sources from phpStorm to DataGrip and this worked: `mv my-project/.idea/dataSources dataSources.* ~/Library/Preferences/DataGrip2017.2/projects/default/.idea/`

## Moving your data sources onto another computer
> [link](https://www.jetbrains.com/help/datagrip/moving-your-data-sources-onto-another-computer.html)
> - About projects
Your data source settings are stored in projects. When you start DataGrip for the first time, the project called default is created, and you work with that project unless you create another one (File | New | Project).
> - Finding out the project locations
> Each project is stored in its own folder. The folders have the same names as your projects (e.g. default).
> To find out where the folder of interest is located, select File | Open Recent | Manage Projects. As a result, your recently used projects and their locations are shown. ~ in the popup means your home directory.
> - Default project locations
> If you haven't found your project yet, here are the default project locations:
````
Windows: <your-home-dir>\.DataGrip<version>\config\projects
macOS: <your-home-dir>/Library/Preferences/DataGrip<version>/projects
Linux: <your-home-dir>/.DataGrip<version>/projects
````
> - Making your data sources available on another computer
> Transfer the project folder of interest onto the destination computer.
On the destination computer, open the folder in DataGrip: start DataGrip, select File | Open, and then select the project folder.

## An open source alternative to datagrip?
> Have you looked at dbeaver? dbeaver does everything I need! thanks!
