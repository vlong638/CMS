   M S B A M L   `   `   `  ����   WpfApplication2+    %WpfApplication2.Windows.CommandWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  CommandWindow��$	��300��$	��300�� J� InputBindings ��  �� Command$ ApplicationCommands.Save��
 �� Key$ F3�� �� 	Modifiers$ Controlf� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ ApplicationCommands.Save��.���  � RowDefinitions �� $	��80* ��� $	��60* �.+�o� $��0��$��0��.@�m� $
��Edit��.@�m� -    m�Name$ menuCopy��$
��Copy��	 m� Command$	 ApplicationCommands.Copy��m� -   $ 	menuPaste��$��Paste��$	 ApplicationCommands.Paste��m� -   $ menuCut��$	��Cut��$	 ApplicationCommands.Cut��m� $
��File��.@�m� -   $ menuSave��$
��Save��$	 ApplicationCommands.Save���� $��ApplicationCommands.Copy���� $ ApplicationCommands.Paste��$ F2��$ Controlf��� -   
 ��Name$
 mainText��$��1��$��0�� �� TextWrapping$
 Wrap=� �� AcceptsReturn . 