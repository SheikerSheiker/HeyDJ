   M S B A M L   `   `   `  ����E  APartyMaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:PartyMaker
PartyMaker  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	       PartyMaker.Result   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:PartyMaker     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	   -   5          �Name$  	ResultWin��5   	    � Title$ Результат��5	   	    � SizeToContent$ Height=�6   $	��500��69    � 
ResizeMode$ NoResize=�6E   .��5
      � .+�5   
   �� ���	#FFFFD3746   �� 5   
   .+�5      �� ���	#FFFF9301$��
0, 0, 0, 2q�6-   ._�5      � ���	#FFFFD876 � ColumnDefinitions 5      �� 5      -   5         ��Name$ Drinks��5   +   $��78 �6;   �� 5      -   5        $ CountBottle��5   +   $	��174 �6@   �� 5      -   5        $ PriceBottle��5   +   $	��140 �6@   �� 5      -   5        $ 	FullPrice��5   +   $��94 �6>   .+�5      �� $��0��6!   .+�5      �� $��Напиток��6$   $��Center=�5       $��Center=�5       $
��5, 2q�5       
���   �$��16(�5       $��Medium"�5        �� Padding$ 2q�5       5      �� 5      ���	#FFFF9301$��
2, 0, 2, 0q�65   $��1��6R   ._�5       �� $)��#Количество бутылок��6$   $��Center=�5!       $��Center=�5"       $
��5, 2q�5#       
���   �$��16(�5%       $��Medium"�5&       $ 2q�5'       5(      �� 5)      ���	#FFFF9301$��
0, 0, 2, 0q�65   $��2��6R   ._�5*      �� $"��Цена за бутылку��6$   $��Center=�5+       $��Center=�5,       $
��5, 2q�5-       
���   �$��16(�5/       $��Medium"�50       $ 2q�51       52      �� 53      $��3��6!   .+�54      �� $��Стоимость��6$   $��Center=�55       $��Center=�56       $
��5, 2q�57       
���   �$��16(�59       $��Medium"�5:       $ 2q�5;       5<      5=      5>      �� 5?      ���	#FFFF9301$��
0, 0, 0, 2q�6-   ._�5@      � ���	#FFFFC64B.+�5A      �� -   5         ��Name$ ListViewResults��5A      $
��Left=�68   $��Disabled=�6S   ��6�   Z� ��5B      �� 5C      .R�5D   "   �  5E   &   �� 5F   *   ��6;   ��  �� ElementName$ Drinks��	 �� Path$	 Width��� 5G   *   ��6;   �� $ CountBottle��$	 Width��� 5H   *   ��6;   �� $ PriceBottle��$	 Width��� 5I   *   ��6;   �� $ 	FullPrice��$	 Width�.+�5K   &   �� $��0��6F   
���   �$��14(�6i   $��Center=�6w   $
��auto��6�   ��60   �� *Name+6�   �� 5L   &   $��1��6M   
���   �$��14(�6p   $��Center=�6~   $
��auto��6�   ��60   �� *CountBottle+6�   �� 5M   &   $��2��6M   
���   �$��14(�6p   $��Center=�6~   $
��auto��6�   ��60   �� *PriceBottle+6�   �� 5N   &   $��3��6K   
���   �$��14(�6n   $��Center=�6|   $
��auto��6�   ��60   �� *	FullPrice+6�   5O   #   5P      5R      5S      5T      �� 5U      ���	#FFEB730A$��2q�6-   $��Bottom=�6A   $��Center=�6\   $
��auto��6y   $��0, 30, 0, 10q�6�   
 �� Padding$
 20, 0, 20, 0q�6�    �� CornerRadius$ 25��6�   ._�5V      �� -   5         ��Name$ 
TotalBlock��5V      $��18(�60   $��Medium"�6>   $
��Auto��6R   ���	#FFF61F05$��Berlin Sans FB)�6v   6�   5X      5Y      5Z      5[      