mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:myDrawshapesframev2.dll myDrawshapesframev2.cs

mcs -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:myDrawshapesframev2.dll -out:myDrawshapesv2.exe myDrawshapesmainv2.cs
