# Reverse File Reader

[summary]::
Reads the tail-end of a file using `FileStream.Seek`.

## Install

```
$ dotnet add package Tail
```

## Usage

```cs
// Program.cs

using System;
using static Tail.ReverseFileReader;

namespace Example
{
    static void Main(string[] args)
    {
        string filepath = "./example.txt";
        string content = Read(filepath, 3);
        Console.WriteLine(content);
        // stu
        // vwx
        // yz!
    }
}
```

```
// example.txt
abc
def
ghi
jkl
mno
pqr
stu
vwx
yz!
```
