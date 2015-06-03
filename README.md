# Alien Sales Application

## About

Alien Sales Application allows a user to input a number of data sets, specifying the currency denominations and prices for different vendors, and returns the maximum profit that can be made for each data set. Alien Sales Application is a Windows application programmed in C# with Microsoft Visual Studio Express 2013.

The application executable `AlienSalesApp.exe` can be found [here](https://github.com/moniker001/AlienSalesApplication/tree/master/AlienSalesApplication/AlienSalesApp/bin/Debug).

## Input Format

|Line Number|Description|Contraints|
|---|---|---|
|1 (per input)|Number of data sets|K|
|1 (per data set)|Number of denominations and prices|2 <= D <= 7, 2 <= N <= 10|
|2 (per data set)|Denomination conversion constants|D-1 positive integers, where ith integer specifies number of notes of denomination i+1 equal to 1 note of denomination i|
|Next N lines (per data set)|Price in terms of denominations|D non-negative integers, where ith specifies number of notes of denomination i|

### Example

#### Input

```
2
2 2
2
2 0
0 5
3 3
3 5
1 1 1
3 0 0
1 10 0
```

#### Output

```
Data Set 1:
1
Data Set 2:
44
```
