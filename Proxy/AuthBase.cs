/+ACo-
    Copyright +AKk- 2002, The KPD-Team
    All rights reserved.
    http://www.mentalis.org/

  Redistribution and use in source and binary forms, with or without
  modification, are permitted provided that the following conditions
  are met:

    - Redistributions of source code must retain the above copyright
       notice, this list of conditions and the following disclaimer. 

    - Neither the name of the KPD-Team, nor the names of its contributors
       may be used to endorse or promote products derived from this
       software without specific prior written permission. 

  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
  +ACI-AS IS+ACI- AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
  FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL
  THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
  (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
  SERVICES+ADs- LOSS OF USE, DATA, OR PROFITS+ADs- OR BUSINESS INTERRUPTION)
  HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
  STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
  OF THE POSSIBILITY OF SUCH DAMAGE.
+ACo-/

using System+ADs-
using System.Net+ADs-
using System.Net.Sockets+ADs-
using Org.Mentalis.Proxy+ADs-
using Org.Mentalis.Proxy.Socks+ADs-

namespace Org.Mentalis.Proxy.Socks.Authentication +AHs-

///+ADw-summary+AD4-Defines the signature of the method to be called when the authentication is complete.+ADw-/summary+AD4-
///+ADw-param name+AD0AIg-Success+ACIAPg-Specifies whether the authentication was successfull or not.+ADw-/param+AD4-
internal delegate void AuthenticationCompleteDelegate(bool Success)+ADs-

///+ADw-summary+AD4-Authenticates a user on a SOCKS5 server according to the implemented subprotocol.+ADw-/summary+AD4-
///+ADw-remarks+AD4-This is an abstract class. The subprotocol that's used to authenticate a user is specified in the subclasses of this base class.+ADw-/remarks+AD4-
internal abstract class AuthBase +AHs-
	///+ADw-summary+AD4-Initializes a new instance of the AuthBase class.+ADw-/summary+AD4-
	public AuthBase() +AHsAfQ-
	///+ADw-summary+AD4-Starts the authentication process.+ADw-/summary+AD4-
	///+ADw-remarks+AD4-This abstract method must be implemented in the subclasses, according to the selected subprotocol.+ADw-/remarks+AD4-
	///+ADw-param name+AD0AIg-Connection+ACIAPg-The connection with the SOCKS client.+ADw-/param+AD4-
	///+ADw-param name+AD0AIg-Callback+ACIAPg-The method to call when the authentication is complete.+ADw-/param+AD4-
	internal abstract void StartAuthentication(Socket Connection, AuthenticationCompleteDelegate Callback)+ADs-
	///+ADw-summary+AD4-Gets or sets the Socket connection between the proxy server and the SOCKS client.+ADw-/summary+AD4-
	///+ADw-value+AD4-A Socket instance defining the connection between the proxy server and the local client.+ADw-/value+AD4-
	protected Socket Connection +AHs-
		get +AHs-
			return m+AF8-Connection+ADs-
		+AH0-
		set +AHs-
			if (value +AD0APQ- null)
				throw new ArgumentNullException()+ADs-
			m+AF8-Connection +AD0- value+ADs-
		+AH0-
	+AH0-
	///+ADw-summary+AD4-Gets a buffer that can be used to receive data from the client connection.+ADw-/summary+AD4-
	///+ADw-value+AD4-An array of bytes that can be used to receive data from the client connection.+ADw-/value+AD4-
	protected byte +AFsAXQ- Buffer +AHs-
		get +AHs-
			return m+AF8-Buffer+ADs-
		+AH0-
	+AH0-
	///+ADw-summary+AD4-Gets or sets an array of bytes that can be used to store all received data.+ADw-/summary+AD4-
	///+ADw-value+AD4-An array of bytes that can be used to store all received data.+ADw-/value+AD4-
	protected byte +AFsAXQ- Bytes +AHs-
		get +AHs-
			return m+AF8-Bytes+ADs-
		+AH0-
		set +AHs-
			m+AF8-Bytes +AD0- value+ADs-
		+AH0-
	+AH0-
	///+ADw-summary+AD4-Adds bytes to the array returned by the Bytes property.+ADw-/summary+AD4-
	///+ADw-param name+AD0AIg-NewBytes+ACIAPg-The bytes to add.+ADw-/param+AD4-
	///+ADw-param name+AD0AIg-Cnt+ACIAPg-The number of bytes to add.+ADw-/param+AD4-
	protected void AddBytes(byte +AFsAXQ- NewBytes, int Cnt) +AHs-
		if (Cnt +ADwAPQ- 0 +AHwAfA- NewBytes +AD0APQ- null +AHwAfA- Cnt +AD4- NewBytes.Length)
			return+ADs-
		if (Bytes +AD0APQ- null) +AHs-
			Bytes +AD0- new byte+AFs-Cnt+AF0AOw-
		+AH0- else +AHs-
			byte +AFsAXQ- tmp +AD0- Bytes+ADs-
			Bytes +AD0- new byte+AFs-Bytes.Length   Cnt+AF0AOw-
			Array.Copy(tmp, 0, Bytes, 0, tmp.Length)+ADs-
		+AH0-
		Array.Copy(NewBytes, 0, Bytes, Bytes.Length - Cnt, Cnt)+ADs-
	+AH0-
	///+ADw-summary+AD4-The method to call when the authentication is complete.+ADw-/summary+AD4-
	protected AuthenticationCompleteDelegate Callback+ADs-
	// private variables
	/// +ADw-summary+AD4-Holds the value of the Connection property.+ADw-/summary+AD4-
	private Socket m+AF8-Connection+ADs-
	/// +ADw-summary+AD4-Holds the value of the Buffer property.+ADw-/summary+AD4-
	private byte +AFsAXQ- m+AF8-Buffer +AD0- new byte+AFs-1024+AF0AOw-
	/// +ADw-summary+AD4-Holds the value of the Bytes property.+ADw-/summary+AD4-
	private byte +AFsAXQ- m+AF8-Bytes+ADs-
+AH0-

+AH0-
