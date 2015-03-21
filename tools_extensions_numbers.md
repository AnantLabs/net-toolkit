# Number Extensions #

Here you can see all extensions for numbers. Some functions are only usable for decimal or integer numbers.

## Methods ##

### ToPointer ###

Convert the number into a pointer. **Unsafe**

```
long number = 9L;
IntPtr pointer = number.ToPointer();
```

### ToString ###

Convert the number into a string with the given format options. **Only Integer Numbers**

```
long number = 19L;
Console.WriteLine(number.ToString(IntegerStringFormatType.HexBinary)); //13
Console.WriteLine(number.ToString(IntegerStringFormatType.Decimal)); //19
Console.WriteLine(number.ToString(IntegerStringFormatType.Octed)); //23
Console.WriteLine(number.ToString(IntegerStringFormatType.Binary)); //10011
Console.WriteLine(number.ToString(IntegerStringFormatType.RomanNumeral)); //XIX

===GetSetBits===

Returns the number of set bits.

{{{
long number = 9L;
int countOfBits = number.GetSetBits(); //2
}}}
```

### ToByteSizeString ###

Convert the number to a string to show it as bytes like '100 MB'. **Not for Byte**

```
int number = 128000;
Console.WriteLine(number.ToByteSizeString()); //125KB
Console.WriteLine(number.ToByteSizeString(true)); //125KB
Console.WriteLine(number.ToByteSizeString(false)); //128000B
```

### ToBytes ###

Convert the number into a byte array. **Not for byte**

```
int number = 10000;
byte[] buffer = number.ToBytes();
```

### ToLowXXX ###

Convert the current number to the low bytes part of the next smaller number. (Byte Shifting)

```
int number = 100;
int low = number.ToLowShort(); //100
```

### ToHighXXX ###

Convert the current number to the high bytes part of the next smaller number. (Byte Shifting)

```
int number = 100;
int low = number.ToHighShort(); //0
```

### Round ###

Use Math.Round function. **Only decimal numbers**

### Truncate ###

Truncate the number with the given number of decimals. **Only decimal numbers**

```
double number = 1.2345d;
number = number.Truncate(2);//1.23
```