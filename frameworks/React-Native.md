# React Native

## Handling third party build error on react-native 0.46x.
> The problem is from the curl command and pressing ctrl + c key by user.
> When the download process was interrupted, the curl command do not handle the unfinished or interrupted download file. It just save incomplete file to target file name.
> It means that you may have broken .gz files in ~/.rncache folder.
And it causes the many build failed with file not found errors at build phase.
> You should wait till the Saved to filename message be shown on console. If your build trial failed, you should clean all files on ~/.rncache folder and rerun react-native run-ios command.
> 1. clean ~/.rncache folder.
> 2. Download 4 third party library by manual or Rerun the `react-native run-ios` command and wait to print `curl: Saved to filename message. ` You should check 100% Received status. Never press the ctrl+c on build phase.
> 3. or, Reinstall node_modules `rm -rf node_modules && rm -rf ~/.rncache && yarn`
> 4. `react-native upgrade`

## (BUILD SUCCEEDED, but) Print: Entry, “:CFBundleIdentifier”, Does Not Exist
> 1. Go to File -> Project settings
> 2. Click the Advanced button
> 3. Select "Custom" and select "Relative to Workspace" in the pull down
> 4. Change "Build/Products" to "build/Build/Products" (, and other path.)
> 5. click done, done

## React Native Change Default iOS Simulator Device
> 1. `react-native run-ios --simulator="iPhone 5"` there is currently no way to set a default.
>> To see all the available devices you can use xcrun simctl list devices more info [here](https://facebook.github.io/react-native/docs/running-on-simulator-ios.html).
> 2. You can create an alias at your ~/.bash_profile file: `alias rn-ios="react-native run-ios --simulator \"iPhone 5s (10.0)\""`
> 3. You can also use npm for this by adding an entry to the scripts element of your package.json file. E.g. `"launch-ios": "react-native run-ios --simulator \"iPad Air 2\""`, Then to use this: `npm run launch-ios`
> 4. There is a project setting if you hunt down {project}/node_modules/react-native/local-cli/runIOS/runIOS.js Within there are some options under module.exports including:
````
options: [{
    command: '--simulator [string]',
    description: 'Explicitly set simulator to use',
    default: 'iPhone 7',
  }
````
>> Mine was line 231, simply set that to a valid installed simulator and run react-native run-ios it will run to that simulator by default.
