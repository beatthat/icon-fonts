Below are basic steps to create and use an icon font rendered via Text Mesh Pro


## 1. DOWNLOAD AN ICON FONT

We're using Google Material Icons for this example 

https://github.com/google/material-design-icons/blob/master/iconfont/MaterialIcons-Regular.ttf

## 2. BUILD/CREATE a CODE POINTS ASSET FOR YOUR FONT

We don't want to have to specify a unicode value everywhere we use an icon, so instead we use code points. These are the codepoints for Google Material Icons: 

https://github.com/google/material-design-icons/blob/master/iconfont/codepoints

2.a. Create a new CodePoints asset with (Project Pane - RightClick) => Create => Ape - CodePoints
2.b. Add a code point for each icon you want to use (e.g. these again are the code points for google material icons: https://github.com/google/material-design-icons/blob/master/iconfont/codepoints)
NOTE: this should not be a manual process. Instead we should provide a utility to just build the CodePoints asset from a text file.

## 3. DISPLAY AN ICON USING THE FontIcon COMPONENT
On your GameObject...
1. Add a Text component and assign the IconFont, etc.
2. Add a FontIcon component
2.a. Adding the FontIcon component should trigger auto add of a HasText wrapper component, e.g. UnityUIHasText if you're using UnityEngine.UI.Text. If this doesn't happen automatically, add an {XYZ}HasText component manually
3. Assign the CodePoints asset (created in step 2 above) to the FontIcon
3.b. Once the CodePoints asset has been assigned, icon options should display in a dropdown box and YOU ARE GOOD TO GO

