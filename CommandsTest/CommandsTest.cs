using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using CshConsoleAPI;



namespace CshConsoleTest
{
	[TestClass]
	public class CommandsTest
	{
		public const string CMD_ECHO_PARAM = "hello echo";
		public const string CMD_LINE_ECHO = "echo(hello world)";

		public const string CMD_ADD_PARAM = "10,20,30";
		public const string CMD_LINE_ADD = "Add(10,20,30)";

		public const string CMD_SUB_PARAM = "30,20,10";
		public const string CMD_LINE_SUB = "SUB(30,20,10)";

		public const string CMD_MULT_PARAM = "5,10,15";
		public const string CMD_LINE_MULT = "MULT(5,10,15)";

		public const string CMD_DIV_PARAM = "2,4,6";
		public const string CMD_LINE_DIV = "DIV(2,4,6)";

		private static bool CommandEcho(string[] parameters)
		{
			return (true);
		}
		

		[TestMethod]
		public void TestMethod1()
		{
		}

		[TestMethod]
		public void TestParser()
		{
			//	Check command name parsing.
			Assert.IsTrue(Commands.CMD_ECHO == CommandsApi.CommandName(CMD_LINE_ECHO));

			// Check command parameters parsing.
			string[] parameters = CommandsApi.CommandParams(CMD_LINE_ECHO);
			Assert.IsTrue(1 == parameters.Length);
			return;
		}

		//	Test the echo command function.
		[TestMethod]
		public void TestEcho()
		{
			string[] parameters = CommandsApi.CommandParams(CMD_LINE_ECHO);
			Assert.IsTrue(AppCommands.CommandEcho(parameters));
			return;
		}

		//	Test the commands list using the echo command function.
		[TestMethod]
		public void TestCommandEcho()
		{
			//	Check creating a new commands list.
			Commands pCommands = CommandsApi.CommandsInit();
			Assert.IsNotNull(pCommands);

			//	Check adding echo command to commands list.
			Assert.IsTrue(CommandsApi.CommandAdd(ref pCommands, AppCommands.CMD_ECHO, CommandEcho));

			//	Execute the echo command in the command list.
			Assert.IsTrue(CommandsApi.CommandExec(ref pCommands, CMD_LINE_ECHO));
			return;
		}


		public void TestAdd()
		{
			string[] parameters = CommandsApi.CommandParams(CMD_LINE_ADD);
			Assert.IsTrue(AppCommands.CommandAdd(parameters));
			return;
		}

		public void TestCommandAdd()
		{
			//	Check creating a new commands list.
			Commands pCommands = CommandsApi.CommandsInit();
			Assert.IsNotNull(pCommands);

			//	Check adding echo command to commands list.
			Assert.IsTrue(CommandsApi.CommandAdd(ref pCommands, AppCommands.CMD_ADD, AppCommands.CommandAdd));

			//	Execute the echo command in the command list.
			Assert.IsTrue(CommandsApi.CommandExec(ref pCommands, CMD_LINE_ADD));
			return;
		}

		public void TestSub()
		{
			string[] parameters = CommandsApi.CommandParams(CMD_LINE_SUB);
			Assert.IsTrue(AppCommands.CommandSub(parameters));
			return;
		}
		public void TestCommandSub()
		{
			//	Check creating a new commands list.
			Commands pCommands = CommandsApi.CommandsInit();
			Assert.IsNotNull(pCommands);

			//	Check adding echo command to commands list.
			Assert.IsTrue(CommandsApi.CommandAdd(ref pCommands, AppCommands.CMD_SUB, AppCommands.CommandSub));

			//	Execute the echo command in the command list.
			Assert.IsTrue(CommandsApi.CommandExec(ref pCommands, CMD_LINE_SUB));
			return;
		}

		public void TestMult()
		{
			string[] parameters = CommandsApi.CommandParams(CMD_LINE_MULT);
			Assert.IsTrue(AppCommands.CommandMult(parameters));
			return;
		}
		public void TestCommandMult()
		{
			//	Check creating a new commands list.
			Commands pCommands = CommandsApi.CommandsInit();
			Assert.IsNotNull(pCommands);

			//	Check adding echo command to commands list.
			Assert.IsTrue(CommandsApi.CommandAdd(ref pCommands, AppCommands.CMD_MULT, AppCommands.CommandMult));

			//	Execute the echo command in the command list.
			Assert.IsTrue(CommandsApi.CommandExec(ref pCommands, CMD_LINE_MULT));
			return;
		}
		public void TestDiv()
		{
			string[] parameters = CommandsApi.CommandParams(CMD_LINE_DIV);
			Assert.IsTrue(AppCommands.CommandMult(parameters));
			return;
		}
		public void TestCommandDiv()
		{
			//	Check creating a new commands list.
			Commands pCommands = CommandsApi.CommandsInit();
			Assert.IsNotNull(pCommands);

			//	Check adding echo command to commands list.
			Assert.IsTrue(CommandsApi.CommandAdd(ref pCommands, AppCommands.CMD_DIV, AppCommands.CommandDiv));

			//	Execute the echo command in the command list.
			Assert.IsTrue(CommandsApi.CommandExec(ref pCommands, CMD_LINE_DIV));
			return;
		}
	}
}
