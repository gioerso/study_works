   M S B A M L   `   `   `  ����F  BLab15_ISRPO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Lab15_ISRPOLab15_ISRPO  5   	       Lab15_ISRPO.ExcelParser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Lab15_ISRPO     5   	     � Title$  ExcelParser��5   	   $	��450��6   $	��800��6*   .��5	      � .+�5
   
   �� -   5        $��	LoadExcel��5
   q   $��Загрузить xlsx��6   $
��Left=�6*   $��
341,10,0,0q�6E   $	��Top=�6Y   $��87��6�   6�   �� 5   
   -   5         ��Name$ 	SaveExcel��5   q   $��Сохранить xlsx��6   $
��Left=�6*   $��
341,35,0,0q�6E   $	��Top=�6Y   $��87��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grid1��5      $��10,60,10,10q�6"      AutoGenerateColumns . ��67   �� 5   (   5      5      