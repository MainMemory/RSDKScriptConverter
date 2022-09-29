using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RSDKScriptConverter.ScriptReadModes;
using static RSDKScriptConverter.ScriptParseModes;

namespace RSDKScriptConverter
{
	class ScriptEngineV3 : ScriptEngine
	{
		readonly VarNameList varNames = new VarNameList()
		{
			{ "TempValue0", CommonScrVar.VAR_TEMP0 },
			{ "TempValue1", CommonScrVar.VAR_TEMP1 },
			{ "TempValue2", CommonScrVar.VAR_TEMP2 },
			{ "TempValue3", CommonScrVar.VAR_TEMP3 },
			{ "TempValue4", CommonScrVar.VAR_TEMP4 },
			{ "TempValue5", CommonScrVar.VAR_TEMP5 },
			{ "TempValue6", CommonScrVar.VAR_TEMP6 },
			{ "TempValue7", CommonScrVar.VAR_TEMP7 },
			{ "CheckResult", CommonScrVar.VAR_CHECKRESULT },
			{ "ArrayPos0", CommonScrVar.VAR_ARRAYPOS0 },
			{ "ArrayPos1", CommonScrVar.VAR_ARRAYPOS1 },
			{ "Global", CommonScrVar.VAR_GLOBAL },
			{ "Object.EntityNo", CommonScrVar.VAR_OBJECTENTITYPOS },
			{ "Object.Type", CommonScrVar.VAR_OBJECTTYPE },
			{ "Object.PropertyValue", CommonScrVar.VAR_OBJECTPROPERTYVALUE },
			{ "Object.XPos", CommonScrVar.VAR_OBJECTXPOS },
			{ "Object.YPos", CommonScrVar.VAR_OBJECTYPOS },
			{ "Object.iXPos", CommonScrVar.VAR_OBJECTIXPOS },
			{ "Object.iYPos", CommonScrVar.VAR_OBJECTIYPOS },
			{ "Object.State", CommonScrVar.VAR_OBJECTSTATE },
			{ "Object.Rotation", CommonScrVar.VAR_OBJECTROTATION },
			{ "Object.Scale", CommonScrVar.VAR_OBJECTSCALE },
			{ "Object.Priority", CommonScrVar.VAR_OBJECTPRIORITY },
			{ "Object.DrawOrder", CommonScrVar.VAR_OBJECTDRAWORDER },
			{ "Object.Direction", CommonScrVar.VAR_OBJECTDIRECTION },
			{ "Object.InkEffect", CommonScrVar.VAR_OBJECTINKEFFECT },
			{ "Object.Alpha", CommonScrVar.VAR_OBJECTALPHA },
			{ "Object.Frame", CommonScrVar.VAR_OBJECTFRAME },
			{ "Object.Animation", CommonScrVar.VAR_OBJECTANIMATION },
			{ "Object.PrevAnimation", CommonScrVar.VAR_OBJECTPREVANIMATION },
			{ "Object.AnimationSpeed", CommonScrVar.VAR_OBJECTANIMATIONSPEED },
			{ "Object.AnimationTimer", CommonScrVar.VAR_OBJECTANIMATIONTIMER },
			{ "Object.Value0", CommonScrVar.VAR_OBJECTVALUE0 },
			{ "Object.Value1", CommonScrVar.VAR_OBJECTVALUE1 },
			{ "Object.Value2", CommonScrVar.VAR_OBJECTVALUE2 },
			{ "Object.Value3", CommonScrVar.VAR_OBJECTVALUE3 },
			{ "Object.Value4", CommonScrVar.VAR_OBJECTVALUE4 },
			{ "Object.Value5", CommonScrVar.VAR_OBJECTVALUE5 },
			{ "Object.Value6", CommonScrVar.VAR_OBJECTVALUE6 },
			{ "Object.Value7", CommonScrVar.VAR_OBJECTVALUE7 },
			{ "Object.OutOfBounds", CommonScrVar.VAR_OBJECTOUTOFBOUNDS },
			{ "Player.State", CommonScrVar.VAR_PLAYERSTATE },
			{ "Player.ControlMode", CommonScrVar.VAR_PLAYERCONTROLMODE },
			{ "Player.ControlLock", CommonScrVar.VAR_PLAYERCONTROLLOCK },
			{ "Player.CollisionMode", CommonScrVar.VAR_PLAYERCOLLISIONMODE },
			{ "Player.CollisionPlane", CommonScrVar.VAR_PLAYERCOLLISIONPLANE },
			{ "Player.XPos", CommonScrVar.VAR_PLAYERXPOS },
			{ "Player.YPos", CommonScrVar.VAR_PLAYERYPOS },
			{ "Player.iXPos", CommonScrVar.VAR_PLAYERIXPOS },
			{ "Player.iYPos", CommonScrVar.VAR_PLAYERIYPOS },
			{ "Player.ScreenXPos", CommonScrVar.VAR_PLAYERSCREENXPOS },
			{ "Player.ScreenYPos", CommonScrVar.VAR_PLAYERSCREENYPOS },
			{ "Player.Speed", CommonScrVar.VAR_PLAYERSPEED },
			{ "Player.XVelocity", CommonScrVar.VAR_PLAYERXVELOCITY },
			{ "Player.YVelocity", CommonScrVar.VAR_PLAYERYVELOCITY },
			{ "Player.Gravity", CommonScrVar.VAR_PLAYERGRAVITY },
			{ "Player.Angle", CommonScrVar.VAR_PLAYERANGLE },
			{ "Player.Skidding", CommonScrVar.VAR_PLAYERSKIDDING },
			{ "Player.Pushing", CommonScrVar.VAR_PLAYERPUSHING },
			{ "Player.TrackScroll", CommonScrVar.VAR_PLAYERTRACKSCROLL },
			{ "Player.Up", CommonScrVar.VAR_PLAYERUP },
			{ "Player.Down", CommonScrVar.VAR_PLAYERDOWN },
			{ "Player.Left", CommonScrVar.VAR_PLAYERLEFT },
			{ "Player.Right", CommonScrVar.VAR_PLAYERRIGHT },
			{ "Player.JumpPress", CommonScrVar.VAR_PLAYERJUMPPRESS },
			{ "Player.JumpHold", CommonScrVar.VAR_PLAYERJUMPHOLD },
			{ "Player.FollowPlayer1", CommonScrVar.VAR_PLAYERFOLLOWPLAYER1 },
			{ "Player.LookPos", CommonScrVar.VAR_PLAYERLOOKPOS },
			{ "Player.Water", CommonScrVar.VAR_PLAYERWATER },
			{ "Player.TopSpeed", CommonScrVar.VAR_PLAYERTOPSPEED },
			{ "Player.Acceleration", CommonScrVar.VAR_PLAYERACCELERATION },
			{ "Player.Deceleration", CommonScrVar.VAR_PLAYERDECELERATION },
			{ "Player.AirAcceleration", CommonScrVar.VAR_PLAYERAIRACCELERATION },
			{ "Player.AirDeceleration", CommonScrVar.VAR_PLAYERAIRDECELERATION },
			{ "Player.GravityStrength", CommonScrVar.VAR_PLAYERGRAVITYSTRENGTH },
			{ "Player.JumpStrength", CommonScrVar.VAR_PLAYERJUMPSTRENGTH },
			{ "Player.JumpCap", CommonScrVar.VAR_PLAYERJUMPCAP },
			{ "Player.RollingAcceleration", CommonScrVar.VAR_PLAYERROLLINGACCELERATION },
			{ "Player.RollingDeceleration", CommonScrVar.VAR_PLAYERROLLINGDECELERATION },
			{ "Player.EntityNo", CommonScrVar.VAR_PLAYERENTITYNO },
			{ "Player.CollisionLeft", CommonScrVar.VAR_PLAYERCOLLISIONLEFT },
			{ "Player.CollisionTop", CommonScrVar.VAR_PLAYERCOLLISIONTOP },
			{ "Player.CollisionRight", CommonScrVar.VAR_PLAYERCOLLISIONRIGHT },
			{ "Player.CollisionBottom", CommonScrVar.VAR_PLAYERCOLLISIONBOTTOM },
			{ "Player.Flailing", CommonScrVar.VAR_PLAYERFLAILING },
			{ "Player.Timer", CommonScrVar.VAR_PLAYERTIMER },
			{ "Player.TileCollisions", CommonScrVar.VAR_PLAYERTILECOLLISIONS },
			{ "Player.ObjectInteraction", CommonScrVar.VAR_PLAYEROBJECTINTERACTION },
			{ "Player.Visible", CommonScrVar.VAR_PLAYERVISIBLE },
			{ "Player.Rotation", CommonScrVar.VAR_PLAYERROTATION },
			{ "Player.Scale", CommonScrVar.VAR_PLAYERSCALE },
			{ "Player.Priority", CommonScrVar.VAR_PLAYERPRIORITY },
			{ "Player.DrawOrder", CommonScrVar.VAR_PLAYERDRAWORDER },
			{ "Player.Direction", CommonScrVar.VAR_PLAYERDIRECTION },
			{ "Player.InkEffect", CommonScrVar.VAR_PLAYERINKEFFECT },
			{ "Player.Alpha", CommonScrVar.VAR_PLAYERALPHA },
			{ "Player.Frame", CommonScrVar.VAR_PLAYERFRAME },
			{ "Player.Animation", CommonScrVar.VAR_PLAYERANIMATION },
			{ "Player.PrevAnimation", CommonScrVar.VAR_PLAYERPREVANIMATION },
			{ "Player.AnimationSpeed", CommonScrVar.VAR_PLAYERANIMATIONSPEED },
			{ "Player.AnimationTimer", CommonScrVar.VAR_PLAYERANIMATIONTIMER },
			{ "Player.Value0", CommonScrVar.VAR_PLAYERVALUE0 },
			{ "Player.Value1", CommonScrVar.VAR_PLAYERVALUE1 },
			{ "Player.Value2", CommonScrVar.VAR_PLAYERVALUE2 },
			{ "Player.Value3", CommonScrVar.VAR_PLAYERVALUE3 },
			{ "Player.Value4", CommonScrVar.VAR_PLAYERVALUE4 },
			{ "Player.Value5", CommonScrVar.VAR_PLAYERVALUE5 },
			{ "Player.Value6", CommonScrVar.VAR_PLAYERVALUE6 },
			{ "Player.Value7", CommonScrVar.VAR_PLAYERVALUE7 },
			{ "Player.Value8", CommonScrVar.VAR_PLAYERVALUE8 },
			{ "Player.Value9", CommonScrVar.VAR_PLAYERVALUE9 },
			{ "Player.Value10", CommonScrVar.VAR_PLAYERVALUE10 },
			{ "Player.Value11", CommonScrVar.VAR_PLAYERVALUE11 },
			{ "Player.Value12", CommonScrVar.VAR_PLAYERVALUE12 },
			{ "Player.Value13", CommonScrVar.VAR_PLAYERVALUE13 },
			{ "Player.Value14", CommonScrVar.VAR_PLAYERVALUE14 },
			{ "Player.Value15", CommonScrVar.VAR_PLAYERVALUE15 },
			{ "Player.OutOfBounds", CommonScrVar.VAR_PLAYEROUTOFBOUNDS },
			{ "Stage.State", CommonScrVar.VAR_STAGESTATE },
			{ "Stage.ActiveList", CommonScrVar.VAR_STAGEACTIVELIST },
			{ "Stage.ListPos", CommonScrVar.VAR_STAGELISTPOS },
			{ "Stage.TimeEnabled", CommonScrVar.VAR_STAGETIMEENABLED },
			{ "Stage.MilliSeconds", CommonScrVar.VAR_STAGEMILLISECONDS },
			{ "Stage.Seconds", CommonScrVar.VAR_STAGESECONDS },
			{ "Stage.Minutes", CommonScrVar.VAR_STAGEMINUTES },
			{ "Stage.ActNo", CommonScrVar.VAR_STAGEACTNUM },
			{ "Stage.PauseEnabled", CommonScrVar.VAR_STAGEPAUSEENABLED },
			{ "Stage.ListSize", CommonScrVar.VAR_STAGELISTSIZE },
			{ "Stage.NewXBoundary1", CommonScrVar.VAR_STAGENEWXBOUNDARY1 },
			{ "Stage.NewXBoundary2", CommonScrVar.VAR_STAGENEWXBOUNDARY2 },
			{ "Stage.NewYBoundary1", CommonScrVar.VAR_STAGENEWYBOUNDARY1 },
			{ "Stage.NewYBoundary2", CommonScrVar.VAR_STAGENEWYBOUNDARY2 },
			{ "Stage.XBoundary1", CommonScrVar.VAR_STAGECURXBOUNDARY1 },
			{ "Stage.XBoundary2", CommonScrVar.VAR_STAGECURXBOUNDARY2 },
			{ "Stage.YBoundary1", CommonScrVar.VAR_STAGECURYBOUNDARY1 },
			{ "Stage.YBoundary2", CommonScrVar.VAR_STAGECURYBOUNDARY2 },
			{ "Stage.DeformationData0", CommonScrVar.VAR_STAGEDEFORMATIONDATA0 },
			{ "Stage.DeformationData1", CommonScrVar.VAR_STAGEDEFORMATIONDATA1 },
			{ "Stage.DeformationData2", CommonScrVar.VAR_STAGEDEFORMATIONDATA2 },
			{ "Stage.deformationData3", CommonScrVar.VAR_STAGEDEFORMATIONDATA3 },
			{ "Stage.WaterLevel", CommonScrVar.VAR_STAGEWATERLEVEL },
			{ "Stage.ActiveLayer", CommonScrVar.VAR_STAGEACTIVELAYER },
			{ "Stage.MidPoint", CommonScrVar.VAR_STAGEMIDPOINT },
			{ "Stage.PlayerListPos", CommonScrVar.VAR_STAGEPLAYERLISTPOS },
			{ "Stage.ActivePlayer", CommonScrVar.VAR_STAGEACTIVEPLAYER },
			{ "Screen.CameraEnabled", CommonScrVar.VAR_SCREENCAMERAENABLED },
			{ "Screen.CameraTarget", CommonScrVar.VAR_SCREENCAMERATARGET },
			{ "Screen.CameraStyle", CommonScrVar.VAR_SCREENCAMERASTYLE },
			{ "Screen.DrawListSize", CommonScrVar.VAR_SCREENDRAWLISTSIZE },
			{ "Screen.CenterX", CommonScrVar.VAR_SCREENXCENTER },
			{ "Screen.CenterY", CommonScrVar.VAR_SCREENYCENTER },
			{ "Screen.XSize", CommonScrVar.VAR_SCREENXSIZE },
			{ "Screen.YSize", CommonScrVar.VAR_SCREENYSIZE },
			{ "Screen.XOffset", CommonScrVar.VAR_SCREENXOFFSET },
			{ "Screen.YOffset", CommonScrVar.VAR_SCREENYOFFSET },
			{ "Screen.ShakeX", CommonScrVar.VAR_SCREENSHAKEX },
			{ "Screen.ShakeY", CommonScrVar.VAR_SCREENSHAKEY },
			{ "Screen.AdjustCameraY", CommonScrVar.VAR_SCREENADJUSTCAMERAY },
			{ "Touchscreen.Down", CommonScrVar.VAR_TOUCHSCREENDOWN },
			{ "Touchscreen.XPos", CommonScrVar.VAR_TOUCHSCREENXPOS },
			{ "Touchscreen.YPos", CommonScrVar.VAR_TOUCHSCREENYPOS },
			{ "Music.Volume", CommonScrVar.VAR_MUSICVOLUME },
			{ "Music.CurrentTrack", CommonScrVar.VAR_MUSICCURRENTTRACK },
			{ "KeyDown.Up", CommonScrVar.VAR_KEYDOWNUP },
			{ "KeyDown.Down", CommonScrVar.VAR_KEYDOWNDOWN },
			{ "KeyDown.Left", CommonScrVar.VAR_KEYDOWNLEFT },
			{ "KeyDown.Right", CommonScrVar.VAR_KEYDOWNRIGHT },
			{ "KeyDown.ButtonA", CommonScrVar.VAR_KEYDOWNBUTTONA },
			{ "KeyDown.ButtonB", CommonScrVar.VAR_KEYDOWNBUTTONB },
			{ "KeyDown.ButtonC", CommonScrVar.VAR_KEYDOWNBUTTONC },
			{ "KeyDown.Start", CommonScrVar.VAR_KEYDOWNSTART },
			{ "KeyPress.Up", CommonScrVar.VAR_KEYPRESSUP },
			{ "KeyPress.Down", CommonScrVar.VAR_KEYPRESSDOWN },
			{ "KeyPress.Left", CommonScrVar.VAR_KEYPRESSLEFT },
			{ "KeyPress.Right", CommonScrVar.VAR_KEYPRESSRIGHT },
			{ "KeyPress.ButtonA", CommonScrVar.VAR_KEYPRESSBUTTONA },
			{ "KeyPress.ButtonB", CommonScrVar.VAR_KEYPRESSBUTTONB },
			{ "KeyPress.ButtonC", CommonScrVar.VAR_KEYPRESSBUTTONC },
			{ "KeyPress.Start", CommonScrVar.VAR_KEYPRESSSTART },
			{ "Menu1.Selection", CommonScrVar.VAR_MENU1SELECTION },
			{ "Menu2.Selection", CommonScrVar.VAR_MENU2SELECTION },
			{ "TileLayer.XSize", CommonScrVar.VAR_TILELAYERXSIZE },
			{ "TileLayer.YSize", CommonScrVar.VAR_TILELAYERYSIZE },
			{ "TileLayer.Type", CommonScrVar.VAR_TILELAYERTYPE },
			{ "TileLayer.Angle", CommonScrVar.VAR_TILELAYERANGLE },
			{ "TileLayer.XPos", CommonScrVar.VAR_TILELAYERXPOS },
			{ "TileLayer.YPos", CommonScrVar.VAR_TILELAYERYPOS },
			{ "TileLayer.ZPos", CommonScrVar.VAR_TILELAYERZPOS },
			{ "TileLayer.ParallaxFactor", CommonScrVar.VAR_TILELAYERPARALLAXFACTOR },
			{ "TileLayer.ScrollSpeed", CommonScrVar.VAR_TILELAYERSCROLLSPEED },
			{ "TileLayer.ScrollPos", CommonScrVar.VAR_TILELAYERSCROLLPOS },
			{ "TileLayer.DeformationOffset", CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSET },
			{ "TileLayer.DeformationOffsetW", CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSETW },
			{ "HParallax.ParallaxFactor", CommonScrVar.VAR_HPARALLAXPARALLAXFACTOR },
			{ "HParallax.ScrollSpeed", CommonScrVar.VAR_HPARALLAXSCROLLSPEED },
			{ "HParallax.ScrollPos", CommonScrVar.VAR_HPARALLAXSCROLLPOS },
			{ "VParallax.ParallaxFactor", CommonScrVar.VAR_VPARALLAXPARALLAXFACTOR },
			{ "VParallax.ScrollSpeed", CommonScrVar.VAR_VPARALLAXSCROLLSPEED },
			{ "VParallax.ScrollPos", CommonScrVar.VAR_VPARALLAXSCROLLPOS },
			{ "3DScene.NoVertices", CommonScrVar.VAR_SCENE3DVERTEXCOUNT },
			{ "3DScene.NoFaces", CommonScrVar.VAR_SCENE3DFACECOUNT },
			{ "VertexBuffer.X", CommonScrVar.VAR_VERTEXBUFFERX },
			{ "VertexBuffer.Y", CommonScrVar.VAR_VERTEXBUFFERY },
			{ "VertexBuffer.Z", CommonScrVar.VAR_VERTEXBUFFERZ },
			{ "VertexBuffer.U", CommonScrVar.VAR_VERTEXBUFFERU },
			{ "VertexBuffer.V", CommonScrVar.VAR_VERTEXBUFFERV },
			{ "FaceBuffer.A", CommonScrVar.VAR_FACEBUFFERA },
			{ "FaceBuffer.B", CommonScrVar.VAR_FACEBUFFERB },
			{ "FaceBuffer.C", CommonScrVar.VAR_FACEBUFFERC },
			{ "FaceBuffer.D", CommonScrVar.VAR_FACEBUFFERD },
			{ "FaceBuffer.Flag", CommonScrVar.VAR_FACEBUFFERFLAG },
			{ "FaceBuffer.Color", CommonScrVar.VAR_FACEBUFFERCOLOR },
			{ "3DScene.ProjectionX", CommonScrVar.VAR_SCENE3DPROJECTIONX },
			{ "3DScene.ProjectionY", CommonScrVar.VAR_SCENE3DPROJECTIONY },
			{ "Engine.State", CommonScrVar.VAR_ENGINESTATE },
			{ "Stage.DebugMode", CommonScrVar.VAR_STAGEDEBUGMODE },
			{ "Engine.Message", CommonScrVar.VAR_ENGINEMESSAGE },
			{ "SaveRAM", CommonScrVar.VAR_SAVERAM },
			{ "Engine.Language", CommonScrVar.VAR_ENGINELANGUAGE },
			{ "Object.SpriteSheet", CommonScrVar.VAR_OBJECTSPRITESHEET },
			{ "Engine.OnlineActive", CommonScrVar.VAR_ENGINEONLINEACTIVE },
			{ "Engine.FrameSkipTimer", CommonScrVar.VAR_ENGINEFRAMESKIPTIMER },
			{ "Engine.FrameSkipSetting", CommonScrVar.VAR_ENGINEFRAMESKIPSETTING },
			{ "Engine.SFXVolume", CommonScrVar.VAR_ENGINESFXVOLUME },
			{ "Engine.BGMVolume", CommonScrVar.VAR_ENGINEBGMVOLUME },
			{ "Engine.PlatformID", CommonScrVar.VAR_ENGINEPLATFORMID },
			{ "Engine.TrialMode", CommonScrVar.VAR_ENGINETRIALMODE },
			{ "KeyPress.AnyStart", CommonScrVar.VAR_KEYPRESSANYSTART },
			{ "Engine.HapticsEnabled", CommonScrVar.VAR_HAPTICSENABLED },
		};

		readonly FuncNameList funcNames = new FuncNameList()
		{
			{ "End", CommonScrFunc.FUNC_END },
			{ "Equal", CommonScrFunc.FUNC_EQUAL },
			{ "Add", CommonScrFunc.FUNC_ADD },
			{ "Sub", CommonScrFunc.FUNC_SUB },
			{ "Inc", CommonScrFunc.FUNC_INC },
			{ "Dec", CommonScrFunc.FUNC_DEC },
			{ "Mul", CommonScrFunc.FUNC_MUL },
			{ "Div", CommonScrFunc.FUNC_DIV },
			{ "ShR", CommonScrFunc.FUNC_SHR },
			{ "ShL", CommonScrFunc.FUNC_SHL },
			{ "And", CommonScrFunc.FUNC_AND },
			{ "Or", CommonScrFunc.FUNC_OR },
			{ "Xor", CommonScrFunc.FUNC_XOR },
			{ "Mod", CommonScrFunc.FUNC_MOD },
			{ "FlipSign", CommonScrFunc.FUNC_FLIPSIGN },
			{ "CheckEqual", CommonScrFunc.FUNC_CHECKEQUAL },
			{ "CheckGreater", CommonScrFunc.FUNC_CHECKGREATER },
			{ "CheckLower", CommonScrFunc.FUNC_CHECKLOWER },
			{ "CheckNotEqual", CommonScrFunc.FUNC_CHECKNOTEQUAL },
			{ "IfEqual", CommonScrFunc.FUNC_IFEQUAL },
			{ "IfGreater", CommonScrFunc.FUNC_IFGREATER },
			{ "IfGreaterOrEqual", CommonScrFunc.FUNC_IFGREATEROREQUAL },
			{ "IfLower", CommonScrFunc.FUNC_IFLOWER },
			{ "IfLowerOrEqual", CommonScrFunc.FUNC_IFLOWEROREQUAL },
			{ "IfNotEqual", CommonScrFunc.FUNC_IFNOTEQUAL },
			{ "else", CommonScrFunc.FUNC_ELSE },
			{ "endif", CommonScrFunc.FUNC_ENDIF },
			{ "WEqual", CommonScrFunc.FUNC_WEQUAL },
			{ "WGreater", CommonScrFunc.FUNC_WGREATER },
			{ "WGreaterOrEqual", CommonScrFunc.FUNC_WGREATEROREQUAL },
			{ "WLower", CommonScrFunc.FUNC_WLOWER },
			{ "WLowerOrEqual", CommonScrFunc.FUNC_WLOWEROREQUAL },
			{ "WNotEqual", CommonScrFunc.FUNC_WNOTEQUAL },
			{ "loop", CommonScrFunc.FUNC_LOOP },
			{ "switch", CommonScrFunc.FUNC_SWITCH },
			{ "break", CommonScrFunc.FUNC_BREAK },
			{ "endswitch", CommonScrFunc.FUNC_ENDSWITCH },
			{ "Rand", CommonScrFunc.FUNC_RAND },
			{ "Sin", CommonScrFunc.FUNC_SIN },
			{ "Cos", CommonScrFunc.FUNC_COS },
			{ "Sin256", CommonScrFunc.FUNC_SIN256 },
			{ "Cos256", CommonScrFunc.FUNC_COS256 },
			{ "SinChange", CommonScrFunc.FUNC_SINCHANGE },
			{ "CosChange", CommonScrFunc.FUNC_COSCHANGE },
			{ "ATan2", CommonScrFunc.FUNC_ATAN2 },
			{ "Interpolate", CommonScrFunc.FUNC_INTERPOLATE },
			{ "InterpolateXY", CommonScrFunc.FUNC_INTERPOLATEXY },
			{ "LoadSpriteSheet", CommonScrFunc.FUNC_LOADSPRITESHEET },
			{ "RemoveSpriteSheet", CommonScrFunc.FUNC_REMOVESPRITESHEET },
			{ "DrawSprite", CommonScrFunc.FUNC_DRAWSPRITE },
			{ "DrawSpriteXY", CommonScrFunc.FUNC_DRAWSPRITEXY },
			{ "DrawSpriteScreenXY", CommonScrFunc.FUNC_DRAWSPRITESCREENXY },
			{ "DrawTintRect", CommonScrFunc.FUNC_DRAWTINTRECT },
			{ "DrawNumbers", CommonScrFunc.FUNC_DRAWNUMBERS },
			{ "DrawActName", CommonScrFunc.FUNC_DRAWACTNAME },
			{ "DrawMenu", CommonScrFunc.FUNC_DRAWMENU },
			{ "SpriteFrame", CommonScrFunc.FUNC_SPRITEFRAME },
			{ "EditFrame", CommonScrFunc.FUNC_EDITFRAME },
			{ "LoadPalette", CommonScrFunc.FUNC_LOADPALETTE },
			{ "RotatePalette", CommonScrFunc.FUNC_ROTATEPALETTE },
			{ "SetScreenFade", CommonScrFunc.FUNC_SETSCREENFADE },
			{ "SetActivePalette", CommonScrFunc.FUNC_SETACTIVEPALETTE },
			{ "SetPaletteFade", CommonScrFunc.FUNC_SETPALETTEFADE },
			{ "CopyPalette", CommonScrFunc.FUNC_COPYPALETTE },
			{ "ClearScreen", CommonScrFunc.FUNC_CLEARSCREEN },
			{ "DrawSpriteFX", CommonScrFunc.FUNC_DRAWSPRITEFX },
			{ "DrawSpriteScreenFX", CommonScrFunc.FUNC_DRAWSPRITESCREENFX },
			{ "LoadAnimation", CommonScrFunc.FUNC_LOADANIMATION },
			{ "SetupMenu", CommonScrFunc.FUNC_SETUPMENU },
			{ "AddMenuEntry", CommonScrFunc.FUNC_ADDMENUENTRY },
			{ "EditMenuEntry", CommonScrFunc.FUNC_EDITMENUENTRY },
			{ "LoadStage", CommonScrFunc.FUNC_LOADSTAGE },
			{ "DrawRect", CommonScrFunc.FUNC_DRAWRECT },
			{ "ResetObjectEntity", CommonScrFunc.FUNC_RESETOBJECTENTITY },
			{ "PlayerObjectCollision", CommonScrFunc.FUNC_PLAYEROBJECTCOLLISION },
			{ "CreateTempObject", CommonScrFunc.FUNC_CREATETEMPOBJECT },
			{ "BindPlayerToObject", CommonScrFunc.FUNC_BINDPLAYERTOOBJECT },
			{ "PlayerTileCollision", CommonScrFunc.FUNC_PLAYERTILECOLLISION },
			{ "ProcessPlayerControl", CommonScrFunc.FUNC_PROCESSPLAYERCONTROL },
			{ "ProcessAnimation", CommonScrFunc.FUNC_PROCESSANIMATION },
			{ "DrawObjectAnimation", CommonScrFunc.FUNC_DRAWOBJECTANIMATION },
			{ "DrawPlayerAnimation", CommonScrFunc.FUNC_DRAWPLAYERANIMATION },
			{ "SetMusicTrack", CommonScrFunc.FUNC_SETMUSICTRACK },
			{ "PlayMusic", CommonScrFunc.FUNC_PLAYMUSIC },
			{ "StopMusic", CommonScrFunc.FUNC_STOPMUSIC },
			{ "PlaySfx", CommonScrFunc.FUNC_PLAYSFX },
			{ "StopSfx", CommonScrFunc.FUNC_STOPSFX },
			{ "SetSfxAttributes", CommonScrFunc.FUNC_SETSFXATTRIBUTES },
			{ "ObjectTileCollision", CommonScrFunc.FUNC_OBJECTTILECOLLISION },
			{ "ObjectTileGrip", CommonScrFunc.FUNC_OBJECTTILEGRIP },
			{ "LoadVideo", CommonScrFunc.FUNC_LOADVIDEO },
			{ "NextVideoFrame", CommonScrFunc.FUNC_NEXTVIDEOFRAME },
			{ "PlayStageSfx", CommonScrFunc.FUNC_PLAYSTAGESFX },
			{ "StopStageSfx", CommonScrFunc.FUNC_STOPSTAGESFX },
			{ "Not", CommonScrFunc.FUNC_NOT },
			{ "Draw3DScene", CommonScrFunc.FUNC_DRAW3DSCENE },
			{ "SetIdentityMatrix", CommonScrFunc.FUNC_SETIDENTITYMATRIX },
			{ "MatrixMultiply", CommonScrFunc.FUNC_MATRIXMULTIPLY },
			{ "MatrixTranslateXYZ", CommonScrFunc.FUNC_MATRIXTRANSLATEXYZ },
			{ "MatrixScaleXYZ", CommonScrFunc.FUNC_MATRIXSCALEXYZ },
			{ "MatrixRotateX", CommonScrFunc.FUNC_MATRIXROTATEX },
			{ "MatrixRotateY", CommonScrFunc.FUNC_MATRIXROTATEY },
			{ "MatrixRotateZ", CommonScrFunc.FUNC_MATRIXROTATEZ },
			{ "MatrixRotateXYZ", CommonScrFunc.FUNC_MATRIXROTATEXYZ },
			{ "TransformVertices", CommonScrFunc.FUNC_TRANSFORMVERTICES },
			{ "CallFunction", CommonScrFunc.FUNC_CALLFUNCTION },
			{ "EndFunction", CommonScrFunc.FUNC_ENDFUNCTION },
			{ "SetLayerDeformation", CommonScrFunc.FUNC_SETLAYERDEFORMATION },
			{ "CheckTouchRect", CommonScrFunc.FUNC_CHECKTOUCHRECT },
			{ "GetTileLayerEntry", CommonScrFunc.FUNC_GETTILELAYERENTRY },
			{ "SetTileLayerEntry", CommonScrFunc.FUNC_SETTILELAYERENTRY },
			{ "GetBit", CommonScrFunc.FUNC_GETBIT },
			{ "SetBit", CommonScrFunc.FUNC_SETBIT },
			{ "PauseMusic", CommonScrFunc.FUNC_PAUSEMUSIC },
			{ "ResumeMusic", CommonScrFunc.FUNC_RESUMEMUSIC },
			{ "ClearDrawList", CommonScrFunc.FUNC_CLEARDRAWLIST },
			{ "AddDrawListEntityRef", CommonScrFunc.FUNC_ADDDRAWLISTENTITYREF },
			{ "GetDrawListEntityRef", CommonScrFunc.FUNC_GETDRAWLISTENTITYREF },
			{ "SetDrawListEntityRef", CommonScrFunc.FUNC_SETDRAWLISTENTITYREF },
			{ "Get16x16TileInfo", CommonScrFunc.FUNC_GET16X16TILEINFO },
			{ "Copy16x16Tile", CommonScrFunc.FUNC_COPY16X16TILE },
			{ "Set16x16TileInfo", CommonScrFunc.FUNC_SET16X16TILEINFO },
			{ "GetAnimationByName", CommonScrFunc.FUNC_GETANIMATIONBYNAME },
			{ "ReadSaveRAM", CommonScrFunc.FUNC_READSAVERAM },
			{ "WriteSaveRAM", CommonScrFunc.FUNC_WRITESAVERAM },
			{ "LoadTextFont", CommonScrFunc.FUNC_LOADTEXTFONT },
			{ "LoadTextFile", CommonScrFunc.FUNC_LOADTEXTFILE },
			{ "DrawText", CommonScrFunc.FUNC_DRAWTEXT },
			{ "GetTextInfo", CommonScrFunc.FUNC_GETTEXTINFO },
			{ "GetVersionNumber", CommonScrFunc.FUNC_GETVERSIONNUMBER },
			{ "SetAchievement", CommonScrFunc.FUNC_SETACHIEVEMENT },
			{ "SetLeaderboard", CommonScrFunc.FUNC_SETLEADERBOARD },
			{ "LoadOnlineMenu", CommonScrFunc.FUNC_LOADONLINEMENU },
			{ "EngineCallback", CommonScrFunc.FUNC_ENGINECALLBACK },
			{ "HapticEffect", CommonScrFunc.FUNC_HAPTICEFFECT },
		};

		private MaybeVarRef GetVarRef(string value)
		{
			MaybeVarRef index = null;
			int indstart = value.IndexOf('[');
			if (indstart != -1)
			{
				int indend = value.IndexOf(']', indstart);
				if (indend != -1)
				{
					index = GetVarRef(value.Substring(indstart + 1, indend - indstart - 1));
					value = value.Remove(indstart, indend - indstart + 1);
				}
			}
			if (varNames.TryGetValue(value, out CommonScrVar var))
				return new MaybeVarRef(var, value, index);
			else
				return new MaybeVarRef(null, value, index);
		}

		private string GetVarText(MaybeVarRef varRef, System.IO.TextWriter writer)
		{
			string name = varRef.Text;
			if (varRef.Variable.HasValue)
			{
				if (varNames.TryGetValue(varRef.Variable.Value, out string _name))
					name = _name;
				else if (writer != null)
					writer.WriteLine("// WARNING: Variable {0} does not exist in RSDKv3!", varRef.Variable.Value);
			}
			if (varRef.Index != null)
			{
				string index = GetVarText(varRef.Index, writer);
				int ins = name.Length;
				if (varRef.Variable.HasValue)
					switch (varRef.Variable.Value)
					{
						case CommonScrVar.VAR_OBJECTENTITYPOS:
						case CommonScrVar.VAR_OBJECTGROUPID:
						case CommonScrVar.VAR_OBJECTTYPE:
						case CommonScrVar.VAR_OBJECTPROPERTYVALUE:
						case CommonScrVar.VAR_OBJECTXPOS:
						case CommonScrVar.VAR_OBJECTYPOS:
						case CommonScrVar.VAR_OBJECTIXPOS:
						case CommonScrVar.VAR_OBJECTIYPOS:
						case CommonScrVar.VAR_OBJECTXVEL:
						case CommonScrVar.VAR_OBJECTYVEL:
						case CommonScrVar.VAR_OBJECTSPEED:
						case CommonScrVar.VAR_OBJECTSTATE:
						case CommonScrVar.VAR_OBJECTROTATION:
						case CommonScrVar.VAR_OBJECTSCALE:
						case CommonScrVar.VAR_OBJECTPRIORITY:
						case CommonScrVar.VAR_OBJECTDRAWORDER:
						case CommonScrVar.VAR_OBJECTDIRECTION:
						case CommonScrVar.VAR_OBJECTINKEFFECT:
						case CommonScrVar.VAR_OBJECTALPHA:
						case CommonScrVar.VAR_OBJECTFRAME:
						case CommonScrVar.VAR_OBJECTANIMATION:
						case CommonScrVar.VAR_OBJECTPREVANIMATION:
						case CommonScrVar.VAR_OBJECTANIMATIONSPEED:
						case CommonScrVar.VAR_OBJECTANIMATIONTIMER:
						case CommonScrVar.VAR_OBJECTANGLE:
						case CommonScrVar.VAR_OBJECTLOOKPOSX:
						case CommonScrVar.VAR_OBJECTLOOKPOSY:
						case CommonScrVar.VAR_OBJECTCOLLISIONMODE:
						case CommonScrVar.VAR_OBJECTCOLLISIONPLANE:
						case CommonScrVar.VAR_OBJECTCONTROLMODE:
						case CommonScrVar.VAR_OBJECTCONTROLLOCK:
						case CommonScrVar.VAR_OBJECTPUSHING:
						case CommonScrVar.VAR_OBJECTVISIBLE:
						case CommonScrVar.VAR_OBJECTTILECOLLISIONS:
						case CommonScrVar.VAR_OBJECTINTERACTION:
						case CommonScrVar.VAR_OBJECTGRAVITY:
						case CommonScrVar.VAR_OBJECTUP:
						case CommonScrVar.VAR_OBJECTDOWN:
						case CommonScrVar.VAR_OBJECTLEFT:
						case CommonScrVar.VAR_OBJECTRIGHT:
						case CommonScrVar.VAR_OBJECTJUMPPRESS:
						case CommonScrVar.VAR_OBJECTJUMPHOLD:
						case CommonScrVar.VAR_OBJECTSCROLLTRACKING:
						case CommonScrVar.VAR_OBJECTFLOORSENSORL:
						case CommonScrVar.VAR_OBJECTFLOORSENSORC:
						case CommonScrVar.VAR_OBJECTFLOORSENSORR:
						case CommonScrVar.VAR_OBJECTFLOORSENSORLC:
						case CommonScrVar.VAR_OBJECTFLOORSENSORRC:
						case CommonScrVar.VAR_OBJECTCOLLISIONLEFT:
						case CommonScrVar.VAR_OBJECTCOLLISIONTOP:
						case CommonScrVar.VAR_OBJECTCOLLISIONRIGHT:
						case CommonScrVar.VAR_OBJECTCOLLISIONBOTTOM:
						case CommonScrVar.VAR_OBJECTOUTOFBOUNDS:
						case CommonScrVar.VAR_OBJECTSPRITESHEET:
						case CommonScrVar.VAR_OBJECTVALUE0:
						case CommonScrVar.VAR_OBJECTVALUE1:
						case CommonScrVar.VAR_OBJECTVALUE2:
						case CommonScrVar.VAR_OBJECTVALUE3:
						case CommonScrVar.VAR_OBJECTVALUE4:
						case CommonScrVar.VAR_OBJECTVALUE5:
						case CommonScrVar.VAR_OBJECTVALUE6:
						case CommonScrVar.VAR_OBJECTVALUE7:
						case CommonScrVar.VAR_OBJECTVALUE8:
						case CommonScrVar.VAR_OBJECTVALUE9:
						case CommonScrVar.VAR_OBJECTVALUE10:
						case CommonScrVar.VAR_OBJECTVALUE11:
						case CommonScrVar.VAR_OBJECTVALUE12:
						case CommonScrVar.VAR_OBJECTVALUE13:
						case CommonScrVar.VAR_OBJECTVALUE14:
						case CommonScrVar.VAR_OBJECTVALUE15:
						case CommonScrVar.VAR_OBJECTVALUE16:
						case CommonScrVar.VAR_OBJECTVALUE17:
						case CommonScrVar.VAR_OBJECTVALUE18:
						case CommonScrVar.VAR_OBJECTVALUE19:
						case CommonScrVar.VAR_OBJECTVALUE20:
						case CommonScrVar.VAR_OBJECTVALUE21:
						case CommonScrVar.VAR_OBJECTVALUE22:
						case CommonScrVar.VAR_OBJECTVALUE23:
						case CommonScrVar.VAR_OBJECTVALUE24:
						case CommonScrVar.VAR_OBJECTVALUE25:
						case CommonScrVar.VAR_OBJECTVALUE26:
						case CommonScrVar.VAR_OBJECTVALUE27:
						case CommonScrVar.VAR_OBJECTVALUE28:
						case CommonScrVar.VAR_OBJECTVALUE29:
						case CommonScrVar.VAR_OBJECTVALUE30:
						case CommonScrVar.VAR_OBJECTVALUE31:
						case CommonScrVar.VAR_OBJECTVALUE32:
						case CommonScrVar.VAR_OBJECTVALUE33:
						case CommonScrVar.VAR_OBJECTVALUE34:
						case CommonScrVar.VAR_OBJECTVALUE35:
						case CommonScrVar.VAR_OBJECTVALUE36:
						case CommonScrVar.VAR_OBJECTVALUE37:
						case CommonScrVar.VAR_OBJECTVALUE38:
						case CommonScrVar.VAR_OBJECTVALUE39:
						case CommonScrVar.VAR_OBJECTVALUE40:
						case CommonScrVar.VAR_OBJECTVALUE41:
						case CommonScrVar.VAR_OBJECTVALUE42:
						case CommonScrVar.VAR_OBJECTVALUE43:
						case CommonScrVar.VAR_OBJECTVALUE44:
						case CommonScrVar.VAR_OBJECTVALUE45:
						case CommonScrVar.VAR_OBJECTVALUE46:
						case CommonScrVar.VAR_OBJECTVALUE47:
						case CommonScrVar.VAR_TOUCHSCREENDOWN:
						case CommonScrVar.VAR_TOUCHSCREENXPOS:
						case CommonScrVar.VAR_TOUCHSCREENYPOS:
						case CommonScrVar.VAR_KEYDOWNUP:
						case CommonScrVar.VAR_KEYDOWNDOWN:
						case CommonScrVar.VAR_KEYDOWNLEFT:
						case CommonScrVar.VAR_KEYDOWNRIGHT:
						case CommonScrVar.VAR_KEYDOWNBUTTONA:
						case CommonScrVar.VAR_KEYDOWNBUTTONB:
						case CommonScrVar.VAR_KEYDOWNBUTTONC:
						case CommonScrVar.VAR_KEYDOWNBUTTONX:
						case CommonScrVar.VAR_KEYDOWNBUTTONY:
						case CommonScrVar.VAR_KEYDOWNBUTTONZ:
						case CommonScrVar.VAR_KEYDOWNBUTTONL:
						case CommonScrVar.VAR_KEYDOWNBUTTONR:
						case CommonScrVar.VAR_KEYDOWNSTART:
						case CommonScrVar.VAR_KEYDOWNSELECT:
						case CommonScrVar.VAR_KEYPRESSUP:
						case CommonScrVar.VAR_KEYPRESSDOWN:
						case CommonScrVar.VAR_KEYPRESSLEFT:
						case CommonScrVar.VAR_KEYPRESSRIGHT:
						case CommonScrVar.VAR_KEYPRESSBUTTONA:
						case CommonScrVar.VAR_KEYPRESSBUTTONB:
						case CommonScrVar.VAR_KEYPRESSBUTTONC:
						case CommonScrVar.VAR_KEYPRESSBUTTONX:
						case CommonScrVar.VAR_KEYPRESSBUTTONY:
						case CommonScrVar.VAR_KEYPRESSBUTTONZ:
						case CommonScrVar.VAR_KEYPRESSBUTTONL:
						case CommonScrVar.VAR_KEYPRESSBUTTONR:
						case CommonScrVar.VAR_KEYPRESSSTART:
						case CommonScrVar.VAR_KEYPRESSSELECT:
						case CommonScrVar.VAR_TILELAYERXSIZE:
						case CommonScrVar.VAR_TILELAYERYSIZE:
						case CommonScrVar.VAR_TILELAYERTYPE:
						case CommonScrVar.VAR_TILELAYERANGLE:
						case CommonScrVar.VAR_TILELAYERXPOS:
						case CommonScrVar.VAR_TILELAYERYPOS:
						case CommonScrVar.VAR_TILELAYERZPOS:
						case CommonScrVar.VAR_TILELAYERPARALLAXFACTOR:
						case CommonScrVar.VAR_TILELAYERSCROLLSPEED:
						case CommonScrVar.VAR_TILELAYERSCROLLPOS:
						case CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSET:
						case CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSETW:
						case CommonScrVar.VAR_HPARALLAXPARALLAXFACTOR:
						case CommonScrVar.VAR_HPARALLAXSCROLLSPEED:
						case CommonScrVar.VAR_HPARALLAXSCROLLPOS:
						case CommonScrVar.VAR_VPARALLAXPARALLAXFACTOR:
						case CommonScrVar.VAR_VPARALLAXSCROLLSPEED:
						case CommonScrVar.VAR_VPARALLAXSCROLLPOS:
						case CommonScrVar.VAR_VERTEXBUFFERX:
						case CommonScrVar.VAR_VERTEXBUFFERY:
						case CommonScrVar.VAR_VERTEXBUFFERZ:
						case CommonScrVar.VAR_VERTEXBUFFERU:
						case CommonScrVar.VAR_VERTEXBUFFERV:
						case CommonScrVar.VAR_FACEBUFFERA:
						case CommonScrVar.VAR_FACEBUFFERB:
						case CommonScrVar.VAR_FACEBUFFERC:
						case CommonScrVar.VAR_FACEBUFFERD:
						case CommonScrVar.VAR_FACEBUFFERFLAG:
						case CommonScrVar.VAR_FACEBUFFERCOLOR:
						case CommonScrVar.VAR_CAMERAENABLED:
						case CommonScrVar.VAR_CAMERATARGET:
						case CommonScrVar.VAR_CAMERASTYLE:
						case CommonScrVar.VAR_CAMERAXPOS:
						case CommonScrVar.VAR_CAMERAYPOS:
						case CommonScrVar.VAR_CAMERAADJUSTY:
							ins = name.IndexOf('.');
							break;
					}
				return name.Insert(ins, $"[{index}]");
			}
			return name;
		}

		public override List<ScriptLine> ReadScript(string filename)
		{
			List<ScriptLine> result = new List<ScriptLine>();

			using (var filestr = System.IO.File.OpenRead(filename))
			{
				ScriptReadModes readMode = READMODE_NORMAL;
				ScriptParseModes parseMode = PARSEMODE_SCOPELESS;
				char prevChar = '\0';
				char curChar = '\0';

				while (readMode < READMODE_EOF)
				{
					readMode = READMODE_NORMAL;
					StringBuilder scriptTextBuf = new StringBuilder();
					StringBuilder comment = new StringBuilder();

					while (readMode < READMODE_ENDLINE)
					{
						prevChar = curChar;
						curChar = (char)filestr.ReadByte();

						if (readMode == READMODE_COMMENTLINE)
						{
							if (curChar == '\n')
								readMode = READMODE_ENDLINE;
							else if (curChar != '\r')
								comment.Append(curChar);
						}
						if (readMode == READMODE_STRING)
						{
							if (curChar == '\t' || curChar == '\r' || curChar == '\n' || curChar == ';' || readMode >= READMODE_COMMENTLINE)
							{
								if ((curChar == '\n' && prevChar != '\r') || (curChar == '\n' && prevChar == '\r'))
								{
									readMode = READMODE_ENDLINE;
								}
							}
							else if (curChar != '/' || scriptTextBuf.Length <= 0)
							{
								scriptTextBuf.Append(curChar);
								if (curChar == '"')
									readMode = READMODE_NORMAL;
							}
							else if (curChar == '/' && prevChar == '/')
							{
								readMode = READMODE_COMMENTLINE;
								scriptTextBuf.Remove(scriptTextBuf.Length - 1, 1);
							}
							else
							{
								scriptTextBuf.Append(curChar);
							}
						}
						else if (readMode == READMODE_NAME)
						{
							if (curChar == '\r' || curChar == '\n' || curChar == ';' || readMode >= READMODE_COMMENTLINE)
							{
								if ((curChar == '\n' && prevChar != '\r') || (curChar == '\n' && prevChar == '\r') || curChar == ';')
								{
									readMode = READMODE_ENDLINE;
								}
							}
							else if (curChar != '/' || scriptTextBuf.Length <= 0)
							{
								scriptTextBuf.Append(curChar);
								if (curChar == ']')
									readMode = READMODE_NORMAL;
							}
							else if (curChar == '/' && prevChar == '/')
							{
								readMode = READMODE_COMMENTLINE;
								scriptTextBuf.Remove(scriptTextBuf.Length - 1, 1);
							}
							else
							{
								scriptTextBuf.Append(curChar);
							}
						}
						else if (curChar == ' ' || curChar == '\t' || curChar == '\r' || curChar == '\n' || curChar == ';'
								 || readMode >= READMODE_COMMENTLINE)
						{
							if ((curChar == '\n' && prevChar != '\r') || (curChar == '\n' && prevChar == '\r') || curChar == ';')
							{
								readMode = READMODE_ENDLINE;
							}
						}
						else if (curChar != '/' || scriptTextBuf.Length <= 0)
						{
							scriptTextBuf.Append(curChar);
							if (curChar == '"' && readMode != READMODE_NORMAL)
								readMode = READMODE_STRING;

							if (curChar == '[' && readMode == READMODE_NORMAL)
							{
								string tmp = scriptTextBuf.ToString();
								if (tmp.EndsWith("TypeName[") || tmp.EndsWith("SfxName[") || tmp.EndsWith("AchievementName[") || tmp.EndsWith("PlayerName[") || tmp.EndsWith("StageName["))
									readMode = READMODE_NAME;
							}
						}
						else if (curChar == '/' && prevChar == '/')
						{
							readMode = READMODE_COMMENTLINE;
							scriptTextBuf.Remove(scriptTextBuf.Length - 1, 1);
						}
						else
						{
							scriptTextBuf.Append(curChar);
						}

						if (filestr.Position >= filestr.Length)
						{
							readMode = READMODE_EOF;
						}
					}

					string scriptText = scriptTextBuf.ToString();
					ScriptLine line = null;

					switch (parseMode)
					{
						case PARSEMODE_SCOPELESS:
							if (scriptText.StartsWith("#alias"))
							{
								int split = scriptText.IndexOf(':');
								line = new ScriptLineAlias(false, scriptText.Substring(split + 1), GetVarRef(scriptText.Substring(6, split - 6)));
							}

							else if (scriptText.Equals("subObjectMain", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineObjectUpdate();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.Equals("subObjectPlayerInteraction", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineObjectPlayerInteraction();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.Equals("subObjectDraw", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineObjectDraw();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.Equals("subObjectStartup", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineObjectStartup();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.Equals("subRSDKDraw", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineRSDKDraw();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.Equals("subRSDKLoad", StringComparison.OrdinalIgnoreCase))
							{
								line = new ScriptLineRSDKLoad();
								parseMode = PARSEMODE_FUNCTION;
							}

							else if (scriptText.StartsWith("#function"))
							{ // forward decl
								line = new ScriptLineReserveFunction(scriptText.Substring(9));

								parseMode = PARSEMODE_SCOPELESS;
							}
							else if (scriptText.StartsWith("function"))
							{ // regular public decl
								line = new ScriptLineFunction(true, scriptText.Substring(8));
								parseMode = PARSEMODE_FUNCTION;
							}
							break;

						case PARSEMODE_FUNCTION:
							if (scriptText.Length > 0)
							{
								if (scriptText.Equals("endsub", StringComparison.OrdinalIgnoreCase))
								{
									line = new ScriptLineEndEvent();
									parseMode = PARSEMODE_SCOPELESS;
								}
								else if (scriptText.Equals("endfunction", StringComparison.OrdinalIgnoreCase))
								{
									line = new ScriptLineEndFunction();
									parseMode = PARSEMODE_SCOPELESS;
								}
								else if (scriptText.StartsWith("#platform:"))
								{
									line = new ScriptLinePlatform(scriptText.Substring(10));
								}
								else if (scriptText.StartsWith("#endplatform"))
								{
									line = new ScriptLineEndPlatform();
								}
								else
								{
									if (scriptText.StartsWith("if"))
									{
										int strPos = 0;
										string compareOp = null;
										foreach (string tok in conditionalTokens)
										{
											int destStrPos = scriptText.IndexOf(tok);
											if (destStrPos > -1)
											{
												strPos = destStrPos;
												compareOp = tok;
											}
										}

										if (compareOp != null)
											line = new ScriptLineIf(compareOp, GetVarRef(scriptText.Substring(2, strPos - 2).Replace("(", "").Replace(")", "").Replace("=", "")), GetVarRef(scriptText.Substring(strPos + compareOp.Length).Replace("(", "").Replace(")", "").Replace("=", "")));
									}
									else if (scriptText.StartsWith("while"))
									{
										int strPos = 0;
										string compareOp = null;
										foreach (string tok in conditionalTokens)
										{
											int destStrPos = scriptText.IndexOf(tok);
											if (destStrPos > -1)
											{
												strPos = destStrPos;
												compareOp = tok;
											}
										}

										if (compareOp != null)
											line = new ScriptLineIf(compareOp, GetVarRef(scriptText.Substring(5, strPos - 5).Replace("(", "").Replace(")", "").Replace("=", "")), GetVarRef(scriptText.Substring(strPos + compareOp.Length).Replace("(", "").Replace(")", "").Replace("=", "")));
									}
									else if (scriptText.StartsWith("switch"))
									{
										line = new ScriptLineSwitch(GetVarRef(scriptText.Substring(6).Replace("(", "").Replace(")", "").Replace("=", "")));
									}
									else if (scriptText.StartsWith("case"))
									{
										line = new ScriptLineCase(scriptText.Substring(4).Replace(":", ""));
									}
									else if (scriptText.StartsWith("default"))
									{
										line = new ScriptLineDefault();
									}
									else if (scriptText.StartsWith("endswitch"))
									{
										line = new ScriptLineEndSwitch();
									}
									else
									{
										string op = null;
										int opInd = -1;
										foreach (string tok in arithmeticTokens)
										{
											int i = scriptText.IndexOf(tok);
											if (i != -1)
											{
												op = tok;
												opInd = i;
											}
										}
										if (op != null)
										{
											line = new ScriptLineArithmetic(op, GetVarRef(scriptText.Substring(0, opInd)), GetVarRef(scriptText.Substring(opInd + op.Length)));
										}
										else
										{
											int i = scriptText.IndexOf('(');
											if (i != -1)
											{
												string funcname = scriptText.Substring(0, i);
												string[] args = scriptText.Substring(i + 1).Replace("(", "").Replace(")", "").Split(',');
												if (funcNames.TryGetValue(funcname, out CommonScrFunc func))
													line = new ScriptLineFunctionCall(func, args.Select(a => GetVarRef(a)).ToArray());
											}
											else if (funcNames.TryGetValue(scriptText, out CommonScrFunc func))
												line = new ScriptLineFunctionCall(func);
										}
									}
								}
							}
							break;

						default: break;
					}
					if (line == null)
						line = new ScriptLineEmpty();
					line.Comment = comment.ToString();
					result.Add(line);
				}
			}

			return result;
		}

		public override void WriteScript(string filename, List<ScriptLine> scriptLines)
		{
			string indent = string.Empty;
			using (var writer = System.IO.File.CreateText(filename))
				foreach (var line in scriptLines)
				{
					switch (line)
					{
						case ScriptLineEmpty _:
							if (!string.IsNullOrEmpty(line.Comment))
								writer.Write(indent);
							break;
						case ScriptLineAlias alias:
							if (alias.Public)
								writer.WriteLine("// WARNING: All aliases are private in RSDKv3!");
							writer.Write("#alias {0} : {1}", GetVarText(alias.Value, writer), alias.Name);
							break;
						case ScriptLineValue value:
							writer.WriteLine("// WARNING: Values are not supported in RSDKv3!");
							writer.Write("// {0} value {1} = {2}", value.Public ? "public" : "private", value.Name, value.Value);
							break;
						case ScriptLineTable table:
							writer.WriteLine("// WARNING: Tables are not supported in RSDKv3!");
							if (table.Size != null)
								writer.Write("// {0} table {1}[{2}]", table.Public ? "public" : "private", table.Name, table.Size);
							else
								writer.Write("// {0} table {1}", table.Public ? "public" : "private", table.Name);
							break;
						case ScriptLineTableValues tablevalues:
							writer.Write("\t// {0}", string.Join(", ", tablevalues.Values));
							break;
						case ScriptLineEndTable _:
							writer.Write("//end table");
							break;
						case ScriptLineObjectUpdate _:
							writer.Write("sub ObjectMain");
							indent += '\t';
							break;
						case ScriptLineObjectPlayerInteraction _:
							writer.Write("sub ObjectPlayerInteraction");
							indent += '\t';
							break;
						case ScriptLineObjectDraw _:
							writer.Write("sub ObjectDraw");
							indent += '\t';
							break;
						case ScriptLineObjectStartup _:
							writer.Write("sub ObjectStartup");
							indent += '\t';
							break;
						case ScriptLineRSDKDraw _:
							writer.Write("sub RSDKDraw");
							indent += '\t';
							break;
						case ScriptLineRSDKLoad _:
							writer.Write("sub RSDKLoad");
							indent += '\t';
							break;
						case ScriptLineReserveFunction reservefunction:
							writer.Write("#function {0}", reservefunction.Name);
							break;
						case ScriptLineFunction function:
							if (!function.Public)
								writer.WriteLine("// WARNING: All functions are public in RSDKv3!");
							writer.Write("function {0}", function.Name);
							indent += '\t';
							break;
						case ScriptLineEndEvent _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("end sub");
							break;
						case ScriptLineEndFunction _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("end function");
							break;
						case ScriptLinePlatform platform:
							writer.Write("#platform: {0}", platform.Platform);
							break;
						case ScriptLineEndPlatform _:
							writer.Write("#endplatform");
							break;
						case ScriptLineIf _if:
							writer.Write("{0}if {1} {2} {3}", indent, GetVarText(_if.Left, writer), _if.Comparison, GetVarText(_if.Right, writer));
							indent += '\t';
							break;
						case ScriptLineWhile _while:
							writer.Write("{0}while {1} {2} {3}", indent, GetVarText(_while.Left, writer), _while.Comparison, GetVarText(_while.Right, writer));
							indent += '\t';
							break;
						case ScriptLineForEach _foreach:
							writer.WriteLine("// WARNING: ForEach is not supported in RSDKv3!");
							writer.Write("{0}// foreach ({1}, {2}, {3})", indent, GetVarText(_foreach.Type, writer), GetVarText(_foreach.Destination, writer), _foreach.Group);
							indent += '\t';
							break;
						case ScriptLineSwitch _switch:
							writer.Write("{0}switch {1}", indent, GetVarText(_switch.Variable, writer));
							indent += '\t';
							break;
						case ScriptLineCase _case:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("{0}case {1}", indent, _case.Value);
							indent += '\t';
							break;
						case ScriptLineDefault _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("{0}default", indent);
							indent += '\t';
							break;
						case ScriptLineEndSwitch _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("{0}end switch", indent);
							break;
						case ScriptLineArithmetic arithmetic:
							switch (arithmetic.Operator)
							{
								case "++":
								case "--":
									writer.Write("{0}{1}{2}", indent, GetVarText(arithmetic.Left, writer), arithmetic.Operator);
									break;
								default:
									writer.Write("{0}{1} {2} {3}", indent, GetVarText(arithmetic.Left, writer), arithmetic.Operator, GetVarText(arithmetic.Right, writer));
									break;
							}
							break;
						case ScriptLineFunctionCall functioncall:
							if (!funcNames.Contains(functioncall.Function))
							{
								writer.WriteLine("// WARNING: Function {0} does not exist in RSDKv3!", functioncall.Function);
								writer.WriteLine("// Arguments: {0}", string.Join(", ", functioncall.Arguments.Select(a => GetVarText(a, writer))));
							}
							else
							{
								switch (functioncall.Function)
								{
									case CommonScrFunc.FUNC_ELSE:
										if (indent.Length > 0)
											indent = indent.Substring(1);
										writer.Write("{0}{1}", indent, funcNames[functioncall.Function]);
										indent += '\t';
										break;
									case CommonScrFunc.FUNC_ENDIF:
										if (indent.Length > 0)
											indent = indent.Substring(1);
										writer.Write("{0}end if", indent);
										break;
									case CommonScrFunc.FUNC_LOOP:
									case CommonScrFunc.FUNC_NEXT:
										if (indent.Length > 0)
											indent = indent.Substring(1);
										writer.Write("{0}{1}", indent, funcNames[functioncall.Function]);
										break;
									case CommonScrFunc.FUNC_END:
									case CommonScrFunc.FUNC_BREAK:
										writer.Write("{0}{1}", indent, funcNames[functioncall.Function]);
										break;
									default:
										writer.Write("{0}{1}({2})", indent, funcNames[functioncall.Function], string.Join(", ", functioncall.Arguments.Select(a => GetVarText(a, writer))));
										break;
								}
							}
							break;
					}
					if (!string.IsNullOrEmpty(line.Comment))
					{
						if (!(line is ScriptLineEmpty))
							writer.Write(' ');
						writer.Write("//");
						writer.Write(line.Comment);
					}
					writer.WriteLine();
				}
		}
	}
}
