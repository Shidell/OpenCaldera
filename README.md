# OpenCaldera
An open project looking to expand the (Dell) Alienware Graphics Amplifier (Caldera) to support Nvidia RTX 3000 and AMD RX 6000 series GPUs.

This project is designed to probe and potentially expand GPU support in the Alienware Graphics Amplifier (Caldera) to include Nvidia RTX 3000 series and AMD RX 6000 series GPUs.
As of this writing (11/19/2020), Alienware (Dell) has indicated that AGA is "soon to be end of life", and "will not be validated with RTX 3xxx video cards". 
([Source](https://www.dell.com/community/Alienware/AGA-Alienware-Graphic-Amplifier-FAQ/td-p/7243433))

Support for AMD RX 6000 series GPUs at the current time is unknown.

## Initial Release: Version 0.1.0.0

**Requirements:** 64-bit Operating System, .NET Framework 4.8

**Test Setup**

Ensure that an Alienware Graphics Amplifier is attached to your PC, with the latest Alienware Graphics Amplifier software (3.0.13.0) installed. You can verify this by navigating to "C:\Program Files\Alienware\Graphics Amplifier\GraphicsAmplifier.exe", right click, select 'Properties', and selecting the 'Details' tab. You should also have a GPU (working or not working) inserted in the AGA, with all necessary power cables plugged in.

Download the executable ('OpenCaldera.exe') to and double-click to run; it should open a Command Prompt window and write brief output to the screen.

**Expected Output**

Under normal Graphics Amplifier working conditions, the following is the expected result. As of 0.1.0.0, I'm looking to gather information on how this is presented in Graphics Amplifiers with RTX 3000 and RX 6000 series GPUs installed.

![Screenshot](https://github.com/Shidell/OpenCaldera/blob/master/OpenCaldera/Resources/Screenshots/0.1.0.0/OpenCaldera.png)

**Will this damage my Alienware system, Graphics Amplifier, or GPU?**

No, at worst, you may need to reboot your system. However, this is exploratory, and I am not liable for anything that may happen—it is your choice.

## Confirmed Working GPUs

| Manufacturer | AIB | Make | Model | Product Name | Working |
| --- | --- | --- | --- | --- | --- |
AMD | Reference | 5700 | XT | | Confirmed 

### What's Next?

I'll continue to investigate support for RTX 3000 and RX 6000 on Caldera—and provide updates as I have them. At the current time, it isn't clear if the issue preventing RTX 3000 series GPUs from working is a software, driver, or firmware issue. 

I do not have an RTX 3000 series nor RX 6000 series GPU at the moment, so I cannot confirm whether or not RX 6000 series GPUs from AMD might be compatible already, nor can I do advanced debugging and troubleshooting.

I, like most of us, am trying to buy one.

###### For reference

Dell Alienware Graphics Amplifier [Product Page](https://www.dell.com/en-us/shop/alienware-graphics-amplifier/apd/452-bcfe/gaming)

Dell Alienware Graphics Amplifier [Supported Graphics Card List](https://www.dell.com/support/article/en-us/sln300946/alienware-graphics-amplifier-supported-graphics-card-list?lang=en)
