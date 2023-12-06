# mp4ToByteArray
> Convert a .mp4 file to a byte[][] array

To execute this program, simply go into the Program.cs file and replace the mp4FilePath string with the file path of your image.
```
string mp4FilePath = "TestVideo.mp4"; //change this
```
The code will first create chunks of byte[] arrays and then use the FileStream class to turn it into the byte[][] array.
The program also automatically reconstructs the new array into a new image to prove that the array is accurate.
