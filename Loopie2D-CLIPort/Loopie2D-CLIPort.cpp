// Loopie2D-CLIPort.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "Interface.h"

int main()
{
	Loopie2DCLIPort::Application::EnableVisualStyles();
	Loopie2DCLIPort::Application::SetCompatibleTextRenderingDefault(false);
	Loopie2DCLIPort::Application::Run(gcnew Loopie2DCLIPort::Interface());
    return 0;
}