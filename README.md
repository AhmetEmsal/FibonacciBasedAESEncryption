# Fibonacci Based AES Encryption (FAES)

> It is aimed to strengthen the algorithm in terms of cryptography by   using the AES encryption algorithm with fibonacci polynomials.   
The project was developed as a windows desktop application using C# programming language.  
Text, txt files and images can be encrypted and decrypted.
___

## Methods of Algorithm
* Encryption
  * Plain text -> Encrypted text
  * .txt file  -> .faes file
  * Image file -> Encrypted image file  
    Supported extensions as image:
    * .png
    * .jpg
    <details style="margin-top:15px;"> <summary><b>Flowchart</b></summary> <img src="https://user-images.githubusercontent.com/36837237/134496917-31c403a9-4b9b-491a-bdc4-810423534544.png" /> </details>
    
* Decryption
  * Encrypted text -> Plain text
  * .faes file -> .txt file
  * Encrypted image file -> image file  
    Supported extensions as image:
    * .png
    * .jpg
    <details style="margin-top:15px;"> <summary><b>Flowchart</b></summary> <img src="https://user-images.githubusercontent.com/36837237/134497623-8a2a2cc6-f7fa-4b75-890f-ab3046ef2e98.png" /> </details>
---

**[Algorithms are in this file..](FibonacciBasedAESEncryption/faes.cs)**

## Pseudocodes of some functions
<ul>
 <li>
  <a href="FibonacciBasedAESEncryption/faes.cs#L897-L908" target="_blank">sumOfMatricesFunction</a> <br/>
  <details style="margin-top:15px;"> <summary><b>Pseudocode</b></summary> <img src="https://user-images.githubusercontent.com/36837237/134497812-9c899653-9ef0-48cb-9d61-efeed548b410.png" /> </details>
 </li>
 <li>
  <a href="FibonacciBasedAESEncryption/faes.cs#L704-L760" target="_blank">crossTransformation</a> <br/>
  <details style="margin-top:15px;"> <summary><b>Pseudocode</b></summary> <img src="https://user-images.githubusercontent.com/36837237/134497974-b0d78b1c-cd7f-48d0-b997-7e8ac1cc072a.png" /> </details>
 </li>
 <li>
  <a href="FibonacciBasedAESEncryption/faes.cs#L762-L772" target="_blank">sbox</a> <br/>
  <details style="margin-top:15px;"> <summary><b>Pseudocode</b></summary> <img src="https://user-images.githubusercontent.com/36837237/134498030-72a493ef-93f7-43ba-b0a9-e1b7de10b4e2.png" /> </details>
 </li>
 <li>
  <a href="FibonacciBasedAESEncryption/faes.cs#L774-L835" target="_blank">mixColumnsAndRows</a> <br/>
  <details style="margin-top:15px;"> <summary><b>Pseudocode</b></summary> <img src="https://user-images.githubusercontent.com/36837237/134498059-2e961c18-06f5-4880-8bd8-4ff869c06c2b.png" /> </details>
 </li>
 <li>
  <a href="FibonacciBasedAESEncryption/faes.cs#L837-L895" target="_blank">productOfMatrices</a> <br/>
  <details style="margin-top:15px;"> <summary><b>Pseudocode</b></summary> <img src="https://user-images.githubusercontent.com/36837237/134498098-b302a24f-f62b-4d85-9eca-d114595c11bf.png" /> </details>
 </li>
</ul>


## Video
https://user-images.githubusercontent.com/36837237/133888263-ccd58d1d-e5bc-429d-a30a-8631a869b923.mp4
