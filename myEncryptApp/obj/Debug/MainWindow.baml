   M S B A M L   `   `   `  ����G  CmyEncryptApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:myEncryptAppmyEncryptApp  5   	       myEncryptApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:myEncryptApp     5   	     � Title$  Password Protector��5   	   $	��200��6$   $	��340��61    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ NoResize=�6b   .��5	      � .+�5
   
   G� -   5         G�Name$ psd_1��5
      $
��Left=�6%   $��25��6@   $��
155,10,0,0q�6L   $	��Top=�6`   $	��156��6x   $��16(�6�   �� 5   
   $��Input Your Password:��6   $
��Left=�6/   $��	10,10,0,0q�6J   $	��Top=�6]   �� 5   
   -   5         ��Name$ DecryptMyPSD��5      $��DecryptMyFile��6'   $
��Left=�6?   $��175,110,0,0q�6Z   $	��Top=�6o   $	��100��6�   $��23��6�   6�   �� 5   
   -   5        $ EncryptMyPSD��5      $��EncryptMyFile��6'   $
��Left=�6?   $��
65,110,0,0q�6Z   $	��Top=�6n   $	��100��6�   $��23��6�   6�   � 5   
   -   5         �Name$ popup_1��5       � 	StaysOpen .  $��Scroll=�63    � PlacementTarget 6K   ��  �� ElementName$ DecryptMyPSD��.��5      �� -   5        	 ��Name$	 myPopupText_1��5      
�������
�������$��17(�5      $	��100��5      
 �� TextAlignment$
 Center=�5      	PSD Error5   !   5      � 5   
   -   5        $ popup_2��5       .  $��Scroll=�63    6K   �� $ EncryptMyPSD��.��5      �� -   5        $	 myPopupText_2��5      
�������
�������$��17(�5      $	��100��5      $
 Center=�5      	PSD Error5   !   5       5"      5#      