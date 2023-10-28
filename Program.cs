using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string mp4FilePath = "TestVideo.mp4"; // Replace with your file path
        byte[][] mp4ByteArray = ConvertMP4ToByteArray(mp4FilePath);

        // Example: Printing the size of the first chunk
        string outputFilePath = "Reconstructed.mp4"; // Set the output file path

        // Convert the byte[][] back to a .mp4 file
        ConvertByteArrayToMP4(mp4ByteArray, outputFilePath);
        Console.WriteLine($"Size of the first chunk: {mp4ByteArray[0].Length} bytes");
    }

    static byte[][] ConvertMP4ToByteArray(string filePath)
    {
        List<byte[]> byteArrayChunks = new List<byte[]>();

        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            int chunkSize = 1024 * 1024; // 1 MB chunk size (you can adjust this)
            byte[] buffer = new byte[chunkSize];
            int bytesRead;

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                byte[] chunk = new byte[bytesRead];
                Array.Copy(buffer, chunk, bytesRead);
                byteArrayChunks.Add(chunk);
            }
        }

        return byteArrayChunks.ToArray();
    }

    static void ConvertByteArrayToMP4(byte[][] byteArrayChunks, string outputPath)
    {
        using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
        {
            foreach (var chunk in byteArrayChunks)
            {
                fileStream.Write(chunk, 0, chunk.Length);
            }
        }

        Console.WriteLine("MP4 file successfully reconstructed!");
    }
}
