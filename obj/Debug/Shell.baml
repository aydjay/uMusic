   M S B A M L   `   `   `  ����
  uMusic    uMusic.Shell   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Shell��5   	   $	��550��6   $	��525��6$    � Icon$ pic/icon_headphone.ICO��6m    � DataContext 60   ��  �� RelativeSource �� *Self+.��5      �  � RowDefinitions 5   
   �� 5	      $
��35px �6   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   o� .@�5      m� $
��Help��6   .@�5      m� -   5        $��miAboutClick��5   *   $��About��6   6>   5      5      �� 5   
   $��1��6   $��Sources��6    .��5      �  5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$    5      �� 5      $
��Auto �6'   �� 5      $��* �6'   �� 5       $
��Auto �6'   .+�5"      �� $��0��6   $��0��6)   $��Song:��69   �� 5#      -   5        $��txtbTuneLoc��5#   9   $��0��6   $��1��6)   ��6L   �� *Tune+�� 5$      -   5        $��btnTuneBrowse��5$   7   $��0��6   $��2��6&   $��Browse��6h   �� 5%      $��1��6   $��0��6)   $��	Pictures:��69   �� 5&      -   5        $��btnPicBrowse��5&   6   $��1��6   $��2��6&   $��Browse��6g   �� 5'      -   5        $��lstPics��5'   7   $��1��6   $��1��6'   $��2��6c   ��6F   �� *Pics+6c   5(      5)      �� 5*   
   $��2��6   $��Preview��6    .��5+      �� ��6   �� *PreviewImage+66   5,      �� 5-   
   $��3��6   .��6   Render6&   5/      50      