# PasswordValidatorApp

Console application for validating passwords in batch mode.

The password is considered valid if the specified character occurs in the string the specified number of times (from the minimum to the maximum).

## How to use app
### 1. Prepare a file containing lines in the following format:
a 1-5: abcdj

Explanation:
*  'a': is the symbol app is looking for;
*  1-5: minimum and maximum number of occurrences of a character in a password string;
*  abcdj: password string for validation.
 
### 2. Run the app with following command line arguments:
validate --f [pathToFile]

#### example: 
```
appFileName.exe validate --f c:\tmp\psw.txt
```
