   M S B A M L   `   `   `  ����F  BLab14_ISRPO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Lab14_ISRPOLab14_ISRPO  5   	       Lab14_ISRPO.XMLParser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Lab14_ISRPO     5   	     � Title$  	XMLParser��5   	   $	��450��6   $	��800��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      5      �� 5      6!   .+�5   
   �� -   5         ��Name$ listBox��5      �� 5   
   -   5        $��loadXML��5   �   $��1��6   $��Загрузить XML��6!   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   $	��122��6   6�   �� 5   
   -   5        $��editXML��5   �   $��1��6   $��Изменить XML��6!   $
��Left=�68   $��	10,35,0,0q�6S   $	��Top=�6f   $	��122��6~   6�   �� 5   
   $��1��6   $��Имя: ��6    $
��Left=�60   $��	10,60,0,0q�6K   $	��Top=�6^   �� 5   
   -   5        $��nameTextBox��5   �   $��1��6   $
��Left=�6"   $��	12,86,0,0q�6=    �� TextWrapping$
 Wrap=�6P   $��TextBox��6d   $	��Top=�6s   $	��120��6�   6�   �� 5   
   $��1��6   $��Возраст: ��6    $
��Left=�64   $��
12,109,0,0q�6O   $	��Top=�6c   �� 5   
   -   5        $��
ageTextBox��5   �   $��1��6   $
��Left=�6"   $��
12,135,0,0q�6=   $
 Wrap=�6Q   $��TextBox��6e   $	��Top=�6t   $	��120��6�   6�   �� 5   
   -   5         ��Name$ editXML_Copy��5   �   $��1��6   $4��.Удалить первый элемент XML��6!   $
��Left=�6F   $��
180,20,0,0q�6a   $	��Top=�6u   $	��122��6�   6�   5      5      