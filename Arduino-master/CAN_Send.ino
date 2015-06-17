void CAN_Send(int identifier, String message)
{
  char stmp[8] = {0};
  
  message.toCharArray(stmp, 8);

  CAN.sendMsgBuf(identifier, 0, 8, (unsigned char *) stmp);
}
