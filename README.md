# PasswordScrambler

A program that will take a character map and a list of passwords and encrypt them as long as they meet the correct parameters.



Parameters for inputs:

Character Mapping Text File: A fully accessible path with the filename and extension included. For example: C:\Users\james\Downloads\sample_character_map.txt
Each line must contain a character followed by "=>" followed by another charcter. The first character will determine which character is being updated, and the second character will be the character it will become.

Passwords Text File: A fully accessible path with the filename and extension included. For example: C:\Users\james\Downloads\sample_passwords.txt
Each line must contain a string of valid characters.

New Passwords File: A fully accessible location the text file can be uploaded to when the program finishes process. It will be saved with the name: NewPasswords.txt
