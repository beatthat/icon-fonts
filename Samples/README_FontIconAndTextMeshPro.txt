Below are basic steps to create and use an icon font rendered via Text Mesh Pro

=====================================
1. CREATE THE TEXT MESH PRO ICON FONT
=====================================

We're using Text Mesh Pro and Google Material Icons for this project so we need to create an SDF font asset for TMP.

1.a. Download a ttf for an icon font, e.g. https://github.com/google/material-design-icons/blob/master/iconfont/MaterialIcons-Regular.ttf

1.b. Create the Text Mesh Pro font assets and materials for the font

1.b.1. Open (Unity) Window => Text Mesh Pro => Font Asset Creator
1.b.2. Assign the font asset
1.b.3. Resize the altas resolution depending on how many icons (maybe 1024x1024 or 2048x2048)
1.b.4. Set 'Character Set' to 'Unicode Range' and set a range that covers the icons you want included (for example used e000-e999 based on code points)
1.b.5. Click 'Generate Font Atlas' and wait for it to generate (maybe a minute)
1.b.6. Click 'Save Text Mesh Pro Font Asset' and save it where you want it.

=================================================
2. BUILD/CREATE a CODE POINTS ASSET FOR YOUR FONT
=================================================

We don't want to have to specify a unicode value everywhere we use an icon, so instead we use code points. These are the codepoints for Google Material Icons: 

https://github.com/google/material-design-icons/blob/master/iconfont/codepoints

2.a. Create a new CodePoints asset with (Project Pane - RightClick) => Create => Ape - CodePoints
2.b. Add a code point for each icon you want to use (e.g. these again are the code points for google material icons: https://github.com/google/material-design-icons/blob/master/iconfont/codepoints)
NOTE: this should not be a manual process. Instead we should provide a utility to just build the CodePoints asset from a text file.

=================================================================
3. DISPLAY AN ICON USING THE FontIcon COMPONENT AND TEXT MESH PRO
=================================================================
On your GameObject...
1. Add a Text Mesh Pro Text component and assign the IconFont, etc.
2. Add a TMUGUIHasText component (because FontIcon should not be specific to TextMeshPro)
3. Add a FontIcon component
3.a. Assign the CodePoints asset (created in step 2 above) to the FontIcon
3.b. Once the CodePoints asset has been assigned, icon options should display in a dropdown box and YOU ARE GOOD TO GO

