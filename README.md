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

No, at worst, you may need to reboot your system. However, this is exploratory, and I am not liable for anything that may happen.

## Confirmed Working GPUs

| Manufacturer | AIB | Make | Model | Product Name | Working |
| --- | --- | --- | --- | --- | --- |
AMD | Reference | 5700 | XT | | Confirmed 

## What's Next?

I'll continue to investigate support for RTX 3000 and RX 6000 on Caldera—and provide updates as I have them. At the current time, it isn't clear if the issue preventing RTX 3000 series GPUs from working is a software, driver, or firmware issue. 

I do not have an RTX 3000 series nor RX 6000 series GPU at the moment, so I cannot confirm whether or not RX 6000 series GPUs from AMD might be compatible already, nor can I do advanced debugging and troubleshooting.

## Why?

The Alienware Graphics Amplifier is the best eGPU enclosure available—although restricted to Alienware systems, it offers a direct PCIE 4x connection to the CPU, without the overhead and/or bandwidth penalties of Thunderbolt 3.

For myself and many others, it's allowed our laptops to stay cooler while gaming (as they're only cooling the CPU, the dGPU is disabled), and afforded us the benefit of a full-size, full-powered, desktop-class GPU.

It's true that the dGPU in laptops today are stronger, comparatively, than those offered with the Graphics Amplifier initially debuted—but it is still the best option for gaming performance increase for laptops, new or old.

And, because it's a PCIE 4x enclosure with an ATX-compatible Power Supply, I don't believe it should restrict the options of the user. At the current time, Dell is indicating that they will not certify it on the 3080 and 3090 series GPUs from Nvidia, because the built-in AGA PSU is rated for 460w, and can't meet the (potential) power requirements. That's fair—but it's also fair to inform customers and allow them to upgrade and replace the built-in PSU, just as they would in any desktop PC, to accomodate.

(Additionally, the expanding size of GPUs means fitting properly within the Graphics Amplifier is another challenge, which most likely contributes to Dell's decision not to certify 3080/3090 series. I believe this, like the PSU requirements, is best left to the customer. There are many RTX and RX series GPUs that should fit comfortably without any modification; so far, an FE 3070 and (I believe) Reference RX 6800 will fit without any issue.)

## For Reference

Dell Alienware Graphics Amplifier [Product Page](https://www.dell.com/en-us/shop/alienware-graphics-amplifier/apd/452-bcfe/gaming)

Dell Alienware Graphics Amplifier [Supported Graphics Card List](https://www.dell.com/support/article/en-us/sln300946/alienware-graphics-amplifier-supported-graphics-card-list?lang=en)
