   M S B A M L   `   `   `  ����F  BEngVocabApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EngVocabAppEngVocabApp  5   	   $    EngVocabApp.UpdateExistingWord   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:EngVocabApp     5   	     � Title$  Update Existing Word��5   	   $	��550��6&   $	��800��63   $	��800��6?   $	��550��6N   .��5	      � .+�5
   
   �� -   5         ��Name$" InsertNewWordValidationLabel��5
      $�� ��5      $��Center=�5      $��	30,54,0,0q�5      $	��Top=�5      �� 5   
   $��Word: ��6   $��Center=�5      $��62,49,670.333,0q�5      $	��Top=�5       J� RenderTransformOrigin$ 0.404,0.154&�5      $
��16px(�5      $��61��6    � 5   
   -   5         �Name$ InsertNewWordMeaningGrid��5      $	��650��5      $	��650��5      $	��650��6   $	��150��6-   $	��150��6:   $	��150��6J   $��62,121,31.333,49.667q�5      $��Center=�5      $	��Top=�5      .+�5      �� -   5         ��Name$ AddWordMeaningButton��5      $��+��5      $
��Left=�6   $	��Top=�5      $��30��5       $��30��6   $��
620,10,0,0q�6(   $��30��6<   $��30��6J   $��30��6X   $��30��6g   $��16(�5!      $
��Bold"�6   $��UltraExpanded&�61   6M   �� 5"      $
��Left=�6   $��0,10,0,0q�5#      $
��Wrap=�5$      $��18(�5%      $��Word Meanings��5&      $	��Top=�5'      $��30��6,   $	��620��68    �� TextAlignment$ Center=�6D   �� 5(      -   5         ��Name$ WordMeaningScrollViewer��5(      $��Hidden=�6<   $
��Left=�5)      $	��Top=�66   $	��620��6N   $	��100��5*      $	��200��5+      $��0,50,0,0q�5,      $��10q�6-   .��5-      �� -   5         ��Name$ WordMeaningStackPanel��5.      $
��Left=�5/      $	��700��50      $��0q�51      $	��Top=�52      $	��620��53       �� CanVerticallyScroll . $
��Auto=�54      ��. 	 �� CanHorizontallyScroll	 . $
��Auto=�57      
 J� IsManipulationEnabled
 . 58      59      5:      � 5;   
   -   5        $ InsertNewWordExampleGrid��5;      $	��650��5<      $	��650��6   $	��650��6*   $	��150��5=      $	��150��6   $	��150��6,   $��62,300,31.333,49.667q�5>      $��Center=�5?      $	��Top=�5@      .+�5B      �� $
��Left=�6   $��0,10,0,0q�5C      $
��Wrap=�5D      $��18(�5E      $��Examples��5F      $	��Top=�5G      $��30��6,   $	��620��68   $ Center=�6D   �� 5H      -   5        $ AddWordExampleButton��5H      $��+��5I      $
��Left=�6   $	��Top=�5J      $��30��5K      $��30��6   $��
620,10,0,0q�6(   $��30��6<   $��30��6J   $��30��6X   $��30��6g   $��16(�5L      $
��Bold"�6   $��UltraExpanded&�61   6M   �� 5M      -   5        $ WordExampleScrollViewer��5M      $��Hidden=�6<   $
��Left=�5N      $	��Top=�66   $	��620��6N   $	��100��5O      $	��200��5P      $��0,50,0,0q�5Q      .��5R      �� -	   5        $ WordExampleStackPanel��5S      $
��Left=�5T      $	��700��5U      $��0q�5V      $	��Top=�5W      $	��620��5X       . $
��Auto=�5Y      ��. 	 . $
��Auto=�5\      
 . 5]      5^      5_      �� 5`   
   -
   5        $$ UpdateExistingWordSubmitButton��5`      $��Submit��5a      $��Center=�5b      $��	0,480,0,0q�6.   $	��Top=�5c      $��75��6)   $��16(�5e      �� 5f   
   -   5         ��Name$" existingVocabulary_TextBlock��5g      $��Center=�5h      $��
0,55,200,0q�5i      $
��Wrap=�5j      $��	TextBlock��6!   $��16(�5k      $	��Top=�5l      $	��350��5m      5o      5p      