function start()
  Form:SetName("��� �����")
  Form:SetText("� �����", "������", "n �� ����� �����.")
  Form:SetBackImage("test.jpg")
end

function start_2()
  Form:SetText("� ������ �����.")
  Form:SetName(IFS:GetPrivateString("..\\data\\configs\\test.ini", "1", "type"))
end