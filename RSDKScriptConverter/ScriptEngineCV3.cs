using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static RSDKScriptConverter.ScriptReadModes;
using static RSDKScriptConverter.ScriptParseModes;
using System.IO;

namespace RSDKScriptConverter
{
	class ScriptEngineCV3 : ScriptEngine
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
			{ "Object.type", CommonScrVar.VAR_OBJECTTYPE },
			{ "Object.propertyValue", CommonScrVar.VAR_OBJECTPROPERTYVALUE },
			{ "Object.XPos", CommonScrVar.VAR_OBJECTXPOS },
			{ "Object.YPos", CommonScrVar.VAR_OBJECTYPOS },
			{ "Object.XPos >> 16", CommonScrVar.VAR_OBJECTIXPOS },
			{ "Object.YPos >> 16", CommonScrVar.VAR_OBJECTIYPOS },
			{ "Object.state", CommonScrVar.VAR_OBJECTSTATE },
			{ "Object.rotation", CommonScrVar.VAR_OBJECTROTATION },
			{ "Object.scale", CommonScrVar.VAR_OBJECTSCALE },
			{ "Object.priority", CommonScrVar.VAR_OBJECTPRIORITY },
			{ "Object.drawOrder", CommonScrVar.VAR_OBJECTDRAWORDER },
			{ "Object.direction", CommonScrVar.VAR_OBJECTDIRECTION },
			{ "Object.inkEffect", CommonScrVar.VAR_OBJECTINKEFFECT },
			{ "Object.alpha", CommonScrVar.VAR_OBJECTALPHA },
			{ "Object.frame", CommonScrVar.VAR_OBJECTFRAME },
			{ "Object.animation", CommonScrVar.VAR_OBJECTANIMATION },
			{ "Object.prevAnimation", CommonScrVar.VAR_OBJECTPREVANIMATION },
			{ "Object.animationSpeed", CommonScrVar.VAR_OBJECTANIMATIONSPEED },
			{ "Object.animationTimer", CommonScrVar.VAR_OBJECTANIMATIONTIMER },
			{ "Object.values[0]", CommonScrVar.VAR_OBJECTVALUE0 },
			{ "Object.values[1]", CommonScrVar.VAR_OBJECTVALUE1 },
			{ "Object.values[2]", CommonScrVar.VAR_OBJECTVALUE2 },
			{ "Object.values[3]", CommonScrVar.VAR_OBJECTVALUE3 },
			{ "Object.values[4]", CommonScrVar.VAR_OBJECTVALUE4 },
			{ "Object.values[5]", CommonScrVar.VAR_OBJECTVALUE5 },
			{ "Object.values[6]", CommonScrVar.VAR_OBJECTVALUE6 },
			{ "Object.values[7]", CommonScrVar.VAR_OBJECTVALUE7 },
			{ "Object.OutOfBounds", CommonScrVar.VAR_OBJECTOUTOFBOUNDS },
			{ "Player->boundEntity->state", CommonScrVar.VAR_PLAYERSTATE },
			{ "Player->controlMode", CommonScrVar.VAR_PLAYERCONTROLMODE },
			{ "Player->controlLock", CommonScrVar.VAR_PLAYERCONTROLLOCK },
			{ "Player->collisionMode", CommonScrVar.VAR_PLAYERCOLLISIONMODE },
			{ "Player->collisionPlane", CommonScrVar.VAR_PLAYERCOLLISIONPLANE },
			{ "Player->XPos", CommonScrVar.VAR_PLAYERXPOS },
			{ "Player->YPos", CommonScrVar.VAR_PLAYERYPOS },
			{ "Player->XPos >> 16", CommonScrVar.VAR_PLAYERIXPOS },
			{ "Player->YPos >> 16", CommonScrVar.VAR_PLAYERIYPOS },
			{ "Player->screenXPos", CommonScrVar.VAR_PLAYERSCREENXPOS },
			{ "Player->screenYPos", CommonScrVar.VAR_PLAYERSCREENYPOS },
			{ "Player->speed", CommonScrVar.VAR_PLAYERSPEED },
			{ "Player->XVelocity", CommonScrVar.VAR_PLAYERXVELOCITY },
			{ "Player->YVelocity", CommonScrVar.VAR_PLAYERYVELOCITY },
			{ "Player->gravity", CommonScrVar.VAR_PLAYERGRAVITY },
			{ "Player->angle", CommonScrVar.VAR_PLAYERANGLE },
			{ "Player->skidding", CommonScrVar.VAR_PLAYERSKIDDING },
			{ "Player->pushing", CommonScrVar.VAR_PLAYERPUSHING },
			{ "Player->trackScroll", CommonScrVar.VAR_PLAYERTRACKSCROLL },
			{ "Player->up", CommonScrVar.VAR_PLAYERUP },
			{ "Player->down", CommonScrVar.VAR_PLAYERDOWN },
			{ "Player->left", CommonScrVar.VAR_PLAYERLEFT },
			{ "Player->right", CommonScrVar.VAR_PLAYERRIGHT },
			{ "Player->jumpPress", CommonScrVar.VAR_PLAYERJUMPPRESS },
			{ "Player->jumpHold", CommonScrVar.VAR_PLAYERJUMPHOLD },
			{ "Player->followPlayer1", CommonScrVar.VAR_PLAYERFOLLOWPLAYER1 },
			{ "Player->lookPos", CommonScrVar.VAR_PLAYERLOOKPOS },
			{ "Player->water", CommonScrVar.VAR_PLAYERWATER },
			{ "Player->topSpeed", CommonScrVar.VAR_PLAYERTOPSPEED },
			{ "Player->acceleration", CommonScrVar.VAR_PLAYERACCELERATION },
			{ "Player->deceleration", CommonScrVar.VAR_PLAYERDECELERATION },
			{ "Player->airAcceleration", CommonScrVar.VAR_PLAYERAIRACCELERATION },
			{ "Player->airDeceleration", CommonScrVar.VAR_PLAYERAIRDECELERATION },
			{ "Player->gravityStrength", CommonScrVar.VAR_PLAYERGRAVITYSTRENGTH },
			{ "Player->jumpStrength", CommonScrVar.VAR_PLAYERJUMPSTRENGTH },
			{ "Player->jumpCap", CommonScrVar.VAR_PLAYERJUMPCAP },
			{ "Player->rollingAcceleration", CommonScrVar.VAR_PLAYERROLLINGACCELERATION },
			{ "Player->rollingDeceleration", CommonScrVar.VAR_PLAYERROLLINGDECELERATION },
			{ "Player->entityNo", CommonScrVar.VAR_PLAYERENTITYNO },
			{ "Player->CollisionLeft", CommonScrVar.VAR_PLAYERCOLLISIONLEFT },
			{ "Player->CollisionTop", CommonScrVar.VAR_PLAYERCOLLISIONTOP },
			{ "Player->CollisionRight", CommonScrVar.VAR_PLAYERCOLLISIONRIGHT },
			{ "Player->CollisionBottom", CommonScrVar.VAR_PLAYERCOLLISIONBOTTOM },
			{ "Player->flailing", CommonScrVar.VAR_PLAYERFLAILING },
			{ "Player->timer", CommonScrVar.VAR_PLAYERTIMER },
			{ "Player->tileCollisions", CommonScrVar.VAR_PLAYERTILECOLLISIONS },
			{ "Player->objectInteractions", CommonScrVar.VAR_PLAYEROBJECTINTERACTION },
			{ "Player->visible", CommonScrVar.VAR_PLAYERVISIBLE },
			{ "Player->boundEntity->rotation", CommonScrVar.VAR_PLAYERROTATION },
			{ "Player->boundEntity->scale", CommonScrVar.VAR_PLAYERSCALE },
			{ "Player->boundEntity->priority", CommonScrVar.VAR_PLAYERPRIORITY },
			{ "Player->boundEntity->drawOrder", CommonScrVar.VAR_PLAYERDRAWORDER },
			{ "Player->boundEntity->direction", CommonScrVar.VAR_PLAYERDIRECTION },
			{ "Player->boundEntity->inkEffect", CommonScrVar.VAR_PLAYERINKEFFECT },
			{ "Player->boundEntity->alpha", CommonScrVar.VAR_PLAYERALPHA },
			{ "Player->boundEntity->frame", CommonScrVar.VAR_PLAYERFRAME },
			{ "Player->boundEntity->animation", CommonScrVar.VAR_PLAYERANIMATION },
			{ "Player->boundEntity->prevAnimation", CommonScrVar.VAR_PLAYERPREVANIMATION },
			{ "Player->boundEntity->animationSpeed", CommonScrVar.VAR_PLAYERANIMATIONSPEED },
			{ "Player->boundEntity->animationTimer", CommonScrVar.VAR_PLAYERANIMATIONTIMER },
			{ "Player->boundEntity->values[0]", CommonScrVar.VAR_PLAYERVALUE0 },
			{ "Player->boundEntity->values[1]", CommonScrVar.VAR_PLAYERVALUE1 },
			{ "Player->boundEntity->values[2]", CommonScrVar.VAR_PLAYERVALUE2 },
			{ "Player->boundEntity->values[3]", CommonScrVar.VAR_PLAYERVALUE3 },
			{ "Player->boundEntity->values[4]", CommonScrVar.VAR_PLAYERVALUE4 },
			{ "Player->boundEntity->values[5]", CommonScrVar.VAR_PLAYERVALUE5 },
			{ "Player->boundEntity->values[6]", CommonScrVar.VAR_PLAYERVALUE6 },
			{ "Player->boundEntity->values[7]", CommonScrVar.VAR_PLAYERVALUE7 },
			{ "Player->values[0]", CommonScrVar.VAR_PLAYERVALUE8 },
			{ "Player->values[1]", CommonScrVar.VAR_PLAYERVALUE9 },
			{ "Player->values[2]", CommonScrVar.VAR_PLAYERVALUE10 },
			{ "Player->values[3]", CommonScrVar.VAR_PLAYERVALUE11 },
			{ "Player->values[4]", CommonScrVar.VAR_PLAYERVALUE12 },
			{ "Player->values[5]", CommonScrVar.VAR_PLAYERVALUE13 },
			{ "Player->values[6]", CommonScrVar.VAR_PLAYERVALUE14 },
			{ "Player->values[7]", CommonScrVar.VAR_PLAYERVALUE15 },
			{ "Player->OutOfBounds", CommonScrVar.VAR_PLAYEROUTOFBOUNDS },
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

		private bool IsObjectVar(CommonScrVar? variable)
		{
			return variable.HasValue && variable.Value >= CommonScrVar.VAR_OBJECTENTITYPOS && variable.Value <= CommonScrVar.VAR_OBJECTVALUE47;
		}

		Dictionary<string, string> aliasfix = new Dictionary<string, string>();
		Dictionary<string, MaybeVarRef> objaliases = new Dictionary<string, MaybeVarRef>();
		private string GetVarText(MaybeVarRef varRef, System.IO.TextWriter writer)
		{
			string name = varRef.Text;
			CommonScrVar? variable = varRef.Variable;
			MaybeVarRef index = varRef.Index;
			if (objaliases.TryGetValue(name, out MaybeVarRef vr))
			{
				name = vr.Text;
				variable = vr.Variable;
			}
			if (variable.HasValue)
			{
				if (varNames.TryGetValue(variable.Value, out string _name))
					name = _name;
			}
			else if (aliasfix.TryGetValue(name, out string _name))
				name = _name;
			if (index != null)
			{
				string indexstr = GetVarText(index, writer);
				if (IsObjectVar(variable))
				{
					if (indexstr[0] == '+' || indexstr[0] == '-')
						name = name.Replace("Object.", "entity.");
					else
						name = name.Replace("Object.", "ObjectList.");
				}
				int ins = name.Length;
				if (variable.HasValue)
				{
					switch (variable.Value)
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
				}
				return name.Insert(ins, $"[{indexstr}]");
			}
			else if (IsObjectVar(variable))
				name = name.Replace("Object.", "entity->");
			return name;
		}

		public override List<ScriptLine> ReadScript(string filename) => throw new NotImplementedException();

		public override void WriteScript(string filename, List<ScriptLine> scriptLines)
		{
			string typename = Path.GetFileNameWithoutExtension(filename).Replace(' ', '_');
			using (var writer = File.CreateText(Path.ChangeExtension(filename, ".h")))
			{
				foreach (var line in scriptLines)
					switch (line)
					{
						case ScriptLineFunction function:
							writer.WriteLine("extern void {0}(struct Entity{1}* entity);", function.Name, typename);
							break;
					}
				writer.WriteLine();
				writer.WriteLine("struct Entity{0}", typename);
				writer.WriteLine("{");
				writer.WriteLine("\tint32 XPos;");
				writer.WriteLine("\tint32 YPos;");
				writer.WriteLine("\tint32 values[8];");
				writer.WriteLine("\tint32 scale;");
				writer.WriteLine("\tint32 rotation;");
				writer.WriteLine("\tint32 animationTimer;");
				writer.WriteLine("\tint32 animationSpeed;");
				writer.WriteLine("\tuint8 type;");
				writer.WriteLine("\tuint8 propertyValue;");
				writer.WriteLine("\tuint8 state;");
				writer.WriteLine("\tuint8 priority;");
				writer.WriteLine("\tuint8 drawOrder;");
				writer.WriteLine("\tuint8 direction;");
				writer.WriteLine("\tuint8 inkEffect;");
				writer.WriteLine("\tuint8 alpha;");
				writer.WriteLine("\tuint8 animation;");
				writer.WriteLine("\tuint8 prevAnimation;");
				writer.WriteLine("\tuint8 frame;");
				writer.WriteLine("};");
			}
			string indent = string.Empty;
			using (var writer = File.CreateText(Path.ChangeExtension(filename, ".c")))
			{
				foreach (var line in scriptLines)
				{
					switch (line)
					{
						case ScriptLineEmpty _:
							if (!string.IsNullOrEmpty(line.Comment))
								writer.Write(indent);
							break;
						case ScriptLineAlias alias:
							if (!alias.Public)
								writer.Write("#define {0} {1}", aliasfix[alias.Name], GetVarText(alias.Value, writer));
							break;
						case ScriptLineObjectUpdate _:
							writer.Write("void {0}_Main(struct Entity{0}* entity) {{", typename);
							indent += '\t';
							break;
						case ScriptLineObjectDraw _:
							writer.Write("void {0}_Draw(struct Entity{0}* entity) {{", typename);
							indent += '\t';
							break;
						case ScriptLineObjectPlayerInteraction _:
							writer.Write("void {0}_PlayerInteraction(struct Entity{0}* entity) {{", typename);
							indent += '\t';
							break;
						case ScriptLineObjectStartup _:
							writer.Write("void {0}_Startup() {{", typename);
							indent += '\t';
							break;
						case ScriptLineRSDKDraw _:
							writer.Write("void {0}_RSDKDraw(struct Entity{0}* entity) {{", typename);
							indent += '\t';
							break;
						case ScriptLineRSDKLoad _:
							writer.Write("void {0}_RSDKLoad() {{", typename);
							indent += '\t';
							break;
						case ScriptLineReserveFunction reservefunction:
							writer.Write("void {0}(struct Entity{1}* entity);", reservefunction.Name, typename);
							break;
						case ScriptLineFunction function:
							writer.Write("void {0}(struct Entity{1}* entity) {{", function.Name, typename);
							indent += '\t';
							break;
						case ScriptLineEndEvent _:
						case ScriptLineEndFunction _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("}");
							break;
						case ScriptLinePlatform platform:
							writer.Write("#if {0}", platform.Platform);
							break;
						case ScriptLineEndPlatform _:
							writer.Write("#endif");
							break;
						case ScriptLineIf _if:
							writer.Write("{0}if ({1} {2} {3}) {{", indent, GetVarText(_if.Left, writer), _if.Comparison, GetVarText(_if.Right, writer));
							indent += '\t';
							break;
						case ScriptLineWhile _while:
							writer.Write("{0}while ({1} {2} {3}) {{", indent, GetVarText(_while.Left, writer), _while.Comparison, GetVarText(_while.Right, writer));
							indent += '\t';
							break;
						case ScriptLineSwitch _switch:
							writer.Write("{0}switch ({1}) {{", indent, GetVarText(_switch.Variable, writer));
							indent += '\t';
							indent += '\t';
							break;
						case ScriptLineCase _case:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("{0}case {1}:", indent, _case.Value);
							indent += '\t';
							break;
						case ScriptLineDefault _:
							if (indent.Length > 0)
								indent = indent.Substring(1);
							writer.Write("{0}default:", indent);
							indent += '\t';
							break;
						case ScriptLineEndSwitch _:
							if (indent.Length > 1)
								indent = indent.Substring(2);
							writer.Write("{0}}}", indent);
							break;
						case ScriptLineArithmetic arithmetic:
							switch (arithmetic.Operator)
							{
								case "++":
								case "--":
									writer.Write("{0}{1}{2};", indent, GetVarText(arithmetic.Left, writer), arithmetic.Operator);
									break;
								default:
									writer.Write("{0}{1} {2} {3};", indent, GetVarText(arithmetic.Left, writer), arithmetic.Operator, GetVarText(arithmetic.Right, writer));
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
										writer.WriteLine("{0}}}", indent);
										writer.Write("{0}{1} {{", indent, funcNames[functioncall.Function]);
										indent += '\t';
										break;
									case CommonScrFunc.FUNC_ENDIF:
									case CommonScrFunc.FUNC_LOOP:
										if (indent.Length > 0)
											indent = indent.Substring(1);
										writer.Write("{0}}}", indent);
										break;
									case CommonScrFunc.FUNC_BREAK:
									case CommonScrFunc.FUNC_RETURN:
										writer.Write("{0}{1};", indent, funcNames[functioncall.Function]);
										break;
									case CommonScrFunc.FUNC_CALLFUNCTION:
										writer.Write("{0}{1}(entity);", indent, GetVarText(functioncall.Arguments[0], writer));
										break;
									case CommonScrFunc.FUNC_CALLNATIVEFUNCTION:
									case CommonScrFunc.FUNC_CALLNATIVEFUNCTION2:
									case CommonScrFunc.FUNC_CALLNATIVEFUNCTION4:
										writer.Write("{0}{1}({2});", indent, GetVarText(functioncall.Arguments[0], writer), string.Join(", ", functioncall.Arguments.Skip(1).Select(a => GetVarText(a, writer))));
										break;
									default:
										writer.Write("{0}{1}({2});", indent, funcNames[functioncall.Function], string.Join(", ", functioncall.Arguments.Select(a => GetVarText(a, writer))));
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
}
