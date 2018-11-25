/**
 * @file Boxes.h
 * @author matthewpoletin
 */

#pragma once

#include <string>

#ifdef WINDOWS
#include <Windows.h>
#endif

void CreateBox(std::string header, std::string text) {
#ifdef WINDOWS
	LPCTSTR s = L"char";

	MessageBox(
		NULL,
		L"������!",
		L"��� ����",
		MB_YESNO | //�� ��� (������)
		MB_DEFBUTTON1 | //��������� ������
		MB_ICONEXCLAMATION | //��� ������
		MB_DEFAULT_DESKTOP_ONLY
		);
#endif

}
