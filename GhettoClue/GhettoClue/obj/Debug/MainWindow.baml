   M S B A M L   `   `   `  ����E  AGhettoClue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GhettoClue
GhettoClue  5      A%clr-namespace:GhettoClue.UserControlsGhettoClue.UserControls  5      =#clr-namespace:GhettoClue.ConvertersGhettoClue.Converters  5          GhettoClue.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      'gbclr-namespace:GhettoClue     5      4uc%clr-namespace:GhettoClue.UserControls     5      3con#clr-namespace:GhettoClue.Converters     5        � Title$  
MainWindow��5      $��890.135��6   $��1461.636��6'    � 	Resources 5	      (   "GhettoClue.Converters.EnumToString   EnumToString  possibleActionsEnum S� 
MethodName,   &GhettoClue.Converters.CharacterToColor  CharacterToColor,   &GhettoClue.Converters.CharacterToImage  CharacterToImage��%�   &	        &	      &	 6     &	 I       5
      6   S� 5      $ 	GetValues��63     5      6     5      6   5      .��5      � $	��860��6   $	��Top=�6    � RowDefinitions 5      �� 5      $	��508 �6   �� 5      $	��349 �6   �� 5       � ColumnDefinitions 5      �� 5      $	��947 �6   �� 5      $
��225* �6   �� 5      $
��251* �6   .+�5      �� -   5         ��Name$ playerListBox��5      $��2��6#   ��.  $��
0,57,0,342q�6Y   {�.  ��5      �� 5       .R�5!      � $��110px��6    5"      �� 5#   	   $��50 �6   �� 5$   	   �� 5%   	    5'      �� 5(   	   $
��25px �6   �� 5)   	   $
��25px �6   �� 5*   	   $
��25px �6   �� 5+   	   $
��25px �6   .+�5-      �� $��1��6   $��1��6   $��15(�5.      ��5-   ,   �� *Name+��6E   ��  �� 	Converter# [ 5.      �� 5/      $��1��6   $��2��6   $��13(�6K   ��6,   �� *
background+6K   �� 50      $��0��6   $��1��6   $��2��6+   $
��50px��6<   $
��50px��6J   ��51      �� # [ 53   	   54      55      57      �� 59      $��Characters:��6
   $��20(�6    $��Center=�6.   $��2��6K   $��82,10,78,446q�6[   $	��107��6q   �� 5>      -   5         ��Name$ DetectiveNotes��5>      $��1��6'   
���  ��y�6L   �� *+)SuggestionPopUpWindow.ConfirmButton_Click+.+�5?      �� $��Detective Notes:��6   
�������$��Chiller)�69   $��35(�6N   $��Center=�6\   &   System.Windows.Controls.DataGrid  5@      -   5          Name$ DNotes_Characters��5@   %   	   CanUserAddRows	 .  
   AutoGenerateColumns
 .  ��6\   ��    Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Character��6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6.   ��  �� Path$ CharacterValue�4  .System.Windows.Controls.DataGridCheckBoxColumn  5C      $ Known��6    6-   �� $
 Show�5E        5F      -   5        $ DNotes_Weapons��5F   A   	 .  
 .  ��6Y   ��  5G        5H      $ Weapon��6    6*   �� $ WeaponValue�  5I      $ Known��6    6-   �� $
 Show�5K        5L      -   5        $ DNotes_Rooms��5L   %   	 .  
 .  ��6;   ��  5M        5N      $
 Room��6    6(   �� $ 	RoomValue�  5O      $ Known��6    6-   �� $
 Show�5Q      5R      �� 5V      -   5        $ 
PlayerHand��5V      $��2��6#   
���  ��$��1��6I   $��1��6V   y�6g   �� *+)SuggestionPopUpWindow.ConfirmButton_Click+.+�5W      �� $��35(�6   $��Center=�6   
�������$��chiller)�6I   .��6^   
YO HAND:6h     5X      -   5        $ CharacterHand��5X   %   	 .  
 .   5Y        5Z      $ 	Character��6    6.   �� 5\        5]      -   5        $ 
WeaponHand��5]   A   	 .  
 .   5^        5_      $ Weapon��6    6*   �� 5a        5b      -	   5        $ RoomHand��5b   %   	 .  
 .   5c        5d      $
 Room��6    6(   �� 5f      5i      	   GhettoClue.GameBoard	  5m      -
   5         	 Name$ gameControl��5m      �� 5n      -   5         ��Name$ suggest��5n      $��SUGGEST��6   $��20(�6.   $	��150��6R   $��2��6^   $��60,306,57,148q�6n   �� 5o      -   5        $ accuse��5o      $��ACCUSE��6   $��20(�6,   $	��150��6O   $��60,409,57,35q�6[   $��2��6q   �� 5p      -   5        $
 play��5p      $��50��6,   $��50��67   $�� ��6C   $��2��6N   $��198,209,23,90q�6^   $��1��6u   ��5q      �� 5r       �� ImageSource$ Images/play.png��6   5t      �� 5v      -   5        $ pause��5v      $��50��6.   $��50��69   $�� ��6E   $��2��6P   $��198,155,23,144q�6`   $��1��6x   ��5w      �� 5x      $ Images/pause.png��6   5z      (
   "GhettoClue.UserControls.BoardGuide
  5|      -   5         
 Name$ 
boardGuide��5|      $��0��5}   	   $��0��5~   	   $��Right=�5   	   $	��Top=�5�   	   '   !GhettoClue.UserControls.UserGuide  5�      -   5          Name$ 	userGuide��5�      $��2��5�      $��11,478,6,225q�5�      $��2��5�      �� 5�      -   5        $
 turn��5�      $��END TURN��6   $��20(�6,   $��2��6:   $��60,194,57,249q�6J   6a   �� 5�      -   5        $
 roll��5�      $
��ROLL��6,   $��20(�6;   $��2��6J   $��67,145,100,156q�6Z   $��1��6r   �� 5�      -   5         ��Name$ die_placement��5�   
   $��60,203,92,65q�6!   $��2��67    J� RenderTransformOrigin$ 0.5,0.5&�6G   $��1��6g   z�5�      V� 5�      .~�5�      ��  �� ScaleY$ -1Q�6   �� 5�      �� 5�      T� 5�      5�      ��5�      �� 5�       �� 	UriSource$ Images/1.png?�6   5�      �� 5�      -   5        $
 help��5�      
����  �
��� ���$
��Help��6?   $��18(�6N   $��2��6\   $��202,304,10,10q�6l   $��1��6�   $ 0.5,0.5&�6�   5�      5�      