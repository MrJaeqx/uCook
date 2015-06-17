void SerialRead(String* command)
{
  if (Serial.available() > 0)
  {
    while (readNextCharacterFromSerial() != '#')
    {

    }
    while (command->indexOf('%') == -1)
    {
      *command += readNextCharacterFromSerial();
    }
  }
}

char readNextCharacterFromSerial()
{
  int value = -1;
  do
  {
    value = Serial.read();
  }
  while (value == -1);
  return (char) value;
}
