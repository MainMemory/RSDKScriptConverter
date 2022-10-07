using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RSDKScriptConverter
{
	class ScriptEngineCV4 : ScriptEngine
	{
		readonly VarNameList varNames = new VarNameList()
		{
			// Internal Script Values
			{ "temp0", CommonScrVar.VAR_TEMP0 },
			{ "temp1", CommonScrVar.VAR_TEMP1 },
			{ "temp2", CommonScrVar.VAR_TEMP2 },
			{ "temp3", CommonScrVar.VAR_TEMP3 },
			{ "temp4", CommonScrVar.VAR_TEMP4 },
			{ "temp5", CommonScrVar.VAR_TEMP5 },
			{ "temp6", CommonScrVar.VAR_TEMP6 },
			{ "temp7", CommonScrVar.VAR_TEMP7 },
			{ "checkResult", CommonScrVar.VAR_CHECKRESULT },
			{ "arrayPos0", CommonScrVar.VAR_ARRAYPOS0 },
			{ "arrayPos1", CommonScrVar.VAR_ARRAYPOS1 },
			{ "arrayPos2", CommonScrVar.VAR_ARRAYPOS2 },
			{ "arrayPos3", CommonScrVar.VAR_ARRAYPOS3 },
			{ "arrayPos4", CommonScrVar.VAR_ARRAYPOS4 },
			{ "arrayPos5", CommonScrVar.VAR_ARRAYPOS5 },
			{ "arrayPos6", CommonScrVar.VAR_ARRAYPOS6 },
			{ "arrayPos7", CommonScrVar.VAR_ARRAYPOS7 },
			{ "global", CommonScrVar.VAR_GLOBAL },
			{ "local", CommonScrVar.VAR_LOCAL },

			// Object Properties
			{ "object.entityPos", CommonScrVar.VAR_OBJECTENTITYPOS },
			{ "object.groupID", CommonScrVar.VAR_OBJECTGROUPID },
			{ "object.type", CommonScrVar.VAR_OBJECTTYPE },
			{ "object.propertyValue", CommonScrVar.VAR_OBJECTPROPERTYVALUE },
			{ "object.xpos", CommonScrVar.VAR_OBJECTXPOS },
			{ "object.ypos", CommonScrVar.VAR_OBJECTYPOS },
			{ "object.xpos >> 16", CommonScrVar.VAR_OBJECTIXPOS },
			{ "object.ypos >> 16", CommonScrVar.VAR_OBJECTIYPOS },
			{ "object.xvel", CommonScrVar.VAR_OBJECTXVEL },
			{ "object.yvel", CommonScrVar.VAR_OBJECTYVEL },
			{ "object.speed", CommonScrVar.VAR_OBJECTSPEED },
			{ "object.state", CommonScrVar.VAR_OBJECTSTATE },
			{ "object.rotation", CommonScrVar.VAR_OBJECTROTATION },
			{ "object.scale", CommonScrVar.VAR_OBJECTSCALE },
			{ "object.priority", CommonScrVar.VAR_OBJECTPRIORITY },
			{ "object.drawOrder", CommonScrVar.VAR_OBJECTDRAWORDER },
			{ "object.direction", CommonScrVar.VAR_OBJECTDIRECTION },
			{ "object.inkEffect", CommonScrVar.VAR_OBJECTINKEFFECT },
			{ "object.alpha", CommonScrVar.VAR_OBJECTALPHA },
			{ "object.frame", CommonScrVar.VAR_OBJECTFRAME },
			{ "object.animation", CommonScrVar.VAR_OBJECTANIMATION },
			{ "object.prevAnimation", CommonScrVar.VAR_OBJECTPREVANIMATION },
			{ "object.animationSpeed", CommonScrVar.VAR_OBJECTANIMATIONSPEED },
			{ "object.animationTimer", CommonScrVar.VAR_OBJECTANIMATIONTIMER },
			{ "object.angle", CommonScrVar.VAR_OBJECTANGLE },
			{ "object.lookPosX", CommonScrVar.VAR_OBJECTLOOKPOSX },
			{ "object.lookPosY", CommonScrVar.VAR_OBJECTLOOKPOSY },
			{ "object.collisionMode", CommonScrVar.VAR_OBJECTCOLLISIONMODE },
			{ "object.collisionPlane", CommonScrVar.VAR_OBJECTCOLLISIONPLANE },
			{ "object.controlMode", CommonScrVar.VAR_OBJECTCONTROLMODE },
			{ "object.controlLock", CommonScrVar.VAR_OBJECTCONTROLLOCK },
			{ "object.pushing", CommonScrVar.VAR_OBJECTPUSHING },
			{ "object.visible", CommonScrVar.VAR_OBJECTVISIBLE },
			{ "object.tileCollisions", CommonScrVar.VAR_OBJECTTILECOLLISIONS },
			{ "object.objectInteractions", CommonScrVar.VAR_OBJECTINTERACTION },
			{ "object.gravity", CommonScrVar.VAR_OBJECTGRAVITY },
			{ "object.up", CommonScrVar.VAR_OBJECTUP },
			{ "object.down", CommonScrVar.VAR_OBJECTDOWN },
			{ "object.left", CommonScrVar.VAR_OBJECTLEFT },
			{ "object.right", CommonScrVar.VAR_OBJECTRIGHT },
			{ "object.jumpPress", CommonScrVar.VAR_OBJECTJUMPPRESS },
			{ "object.jumpHold", CommonScrVar.VAR_OBJECTJUMPHOLD },
			{ "object.scrollTracking", CommonScrVar.VAR_OBJECTSCROLLTRACKING },
			{ "object.floorSensors[0]", CommonScrVar.VAR_OBJECTFLOORSENSORL },
			{ "object.floorSensors[1]", CommonScrVar.VAR_OBJECTFLOORSENSORC },
			{ "object.floorSensors[2]", CommonScrVar.VAR_OBJECTFLOORSENSORR },
			{ "object.floorSensors[3]", CommonScrVar.VAR_OBJECTFLOORSENSORLC },
			{ "object.floorSensors[4]", CommonScrVar.VAR_OBJECTFLOORSENSORRC },
			{ "object.collisionLeft", CommonScrVar.VAR_OBJECTCOLLISIONLEFT },
			{ "object.collisionTop", CommonScrVar.VAR_OBJECTCOLLISIONTOP },
			{ "object.collisionRight", CommonScrVar.VAR_OBJECTCOLLISIONRIGHT },
			{ "object.collisionBottom", CommonScrVar.VAR_OBJECTCOLLISIONBOTTOM },
			{ "object.outOfBounds", CommonScrVar.VAR_OBJECTOUTOFBOUNDS },
			{ "object.spriteSheet", CommonScrVar.VAR_OBJECTSPRITESHEET },

			// Object Values
			{ "object.values[0]", CommonScrVar.VAR_OBJECTVALUE0 },
			{ "object.values[1]", CommonScrVar.VAR_OBJECTVALUE1 },
			{ "object.values[2]", CommonScrVar.VAR_OBJECTVALUE2 },
			{ "object.values[3]", CommonScrVar.VAR_OBJECTVALUE3 },
			{ "object.values[4]", CommonScrVar.VAR_OBJECTVALUE4 },
			{ "object.values[5]", CommonScrVar.VAR_OBJECTVALUE5 },
			{ "object.values[6]", CommonScrVar.VAR_OBJECTVALUE6 },
			{ "object.values[7]", CommonScrVar.VAR_OBJECTVALUE7 },
			{ "object.values[8]", CommonScrVar.VAR_OBJECTVALUE8 },
			{ "object.values[9]", CommonScrVar.VAR_OBJECTVALUE9 },
			{ "object.values[10]", CommonScrVar.VAR_OBJECTVALUE10 },
			{ "object.values[11]", CommonScrVar.VAR_OBJECTVALUE11 },
			{ "object.values[12]", CommonScrVar.VAR_OBJECTVALUE12 },
			{ "object.values[13]", CommonScrVar.VAR_OBJECTVALUE13 },
			{ "object.values[14]", CommonScrVar.VAR_OBJECTVALUE14 },
			{ "object.values[15]", CommonScrVar.VAR_OBJECTVALUE15 },
			{ "object.values[16]", CommonScrVar.VAR_OBJECTVALUE16 },
			{ "object.values[17]", CommonScrVar.VAR_OBJECTVALUE17 },
			{ "object.values[18]", CommonScrVar.VAR_OBJECTVALUE18 },
			{ "object.values[19]", CommonScrVar.VAR_OBJECTVALUE19 },
			{ "object.values[20]", CommonScrVar.VAR_OBJECTVALUE20 },
			{ "object.values[21]", CommonScrVar.VAR_OBJECTVALUE21 },
			{ "object.values[22]", CommonScrVar.VAR_OBJECTVALUE22 },
			{ "object.values[23]", CommonScrVar.VAR_OBJECTVALUE23 },
			{ "object.values[24]", CommonScrVar.VAR_OBJECTVALUE24 },
			{ "object.values[25]", CommonScrVar.VAR_OBJECTVALUE25 },
			{ "object.values[26]", CommonScrVar.VAR_OBJECTVALUE26 },
			{ "object.values[27]", CommonScrVar.VAR_OBJECTVALUE27 },
			{ "object.values[28]", CommonScrVar.VAR_OBJECTVALUE28 },
			{ "object.values[29]", CommonScrVar.VAR_OBJECTVALUE29 },
			{ "object.values[30]", CommonScrVar.VAR_OBJECTVALUE30 },
			{ "object.values[31]", CommonScrVar.VAR_OBJECTVALUE31 },
			{ "object.values[32]", CommonScrVar.VAR_OBJECTVALUE32 },
			{ "object.values[33]", CommonScrVar.VAR_OBJECTVALUE33 },
			{ "object.values[34]", CommonScrVar.VAR_OBJECTVALUE34 },
			{ "object.values[35]", CommonScrVar.VAR_OBJECTVALUE35 },
			{ "object.values[36]", CommonScrVar.VAR_OBJECTVALUE36 },
			{ "object.values[37]", CommonScrVar.VAR_OBJECTVALUE37 },
			{ "object.values[38]", CommonScrVar.VAR_OBJECTVALUE38 },
			{ "object.values[39]", CommonScrVar.VAR_OBJECTVALUE39 },
			{ "object.values[40]", CommonScrVar.VAR_OBJECTVALUE40 },
			{ "object.values[41]", CommonScrVar.VAR_OBJECTVALUE41 },
			{ "object.values[42]", CommonScrVar.VAR_OBJECTVALUE42 },
			{ "object.values[43]", CommonScrVar.VAR_OBJECTVALUE43 },
			{ "object.values[44]", CommonScrVar.VAR_OBJECTVALUE44 },
			{ "object.values[45]", CommonScrVar.VAR_OBJECTVALUE45 },
			{ "object.values[46]", CommonScrVar.VAR_OBJECTVALUE46 },
			{ "object.values[47]", CommonScrVar.VAR_OBJECTVALUE47 },

			// Stage Properties
			{ "stage.state", CommonScrVar.VAR_STAGESTATE },
			{ "stage.activeList", CommonScrVar.VAR_STAGEACTIVELIST },
			{ "stage.listPos", CommonScrVar.VAR_STAGELISTPOS },
			{ "stage.timeEnabled", CommonScrVar.VAR_STAGETIMEENABLED },
			{ "stage.milliSeconds", CommonScrVar.VAR_STAGEMILLISECONDS },
			{ "stage.seconds", CommonScrVar.VAR_STAGESECONDS },
			{ "stage.minutes", CommonScrVar.VAR_STAGEMINUTES },
			{ "stage.actNum", CommonScrVar.VAR_STAGEACTNUM },
			{ "stage.pauseEnabled", CommonScrVar.VAR_STAGEPAUSEENABLED },
			{ "stage.listSize", CommonScrVar.VAR_STAGELISTSIZE },
			{ "stage.newXBoundary1", CommonScrVar.VAR_STAGENEWXBOUNDARY1 },
			{ "stage.newXBoundary2", CommonScrVar.VAR_STAGENEWXBOUNDARY2 },
			{ "stage.newYBoundary1", CommonScrVar.VAR_STAGENEWYBOUNDARY1 },
			{ "stage.newYBoundary2", CommonScrVar.VAR_STAGENEWYBOUNDARY2 },
			{ "stage.curXBoundary1", CommonScrVar.VAR_STAGECURXBOUNDARY1 },
			{ "stage.curXBoundary2", CommonScrVar.VAR_STAGECURXBOUNDARY2 },
			{ "stage.curYBoundary1", CommonScrVar.VAR_STAGECURYBOUNDARY1 },
			{ "stage.curYBoundary2", CommonScrVar.VAR_STAGECURYBOUNDARY2 },
			{ "stage.deformationData0", CommonScrVar.VAR_STAGEDEFORMATIONDATA0 },
			{ "stage.deformationData1", CommonScrVar.VAR_STAGEDEFORMATIONDATA1 },
			{ "stage.deformationData2", CommonScrVar.VAR_STAGEDEFORMATIONDATA2 },
			{ "stage.deformationData3", CommonScrVar.VAR_STAGEDEFORMATIONDATA3 },
			{ "stage.waterLevel", CommonScrVar.VAR_STAGEWATERLEVEL },
			{ "stage.activeLayer", CommonScrVar.VAR_STAGEACTIVELAYER },
			{ "stage.midPoint", CommonScrVar.VAR_STAGEMIDPOINT },
			{ "stage.playerListPos", CommonScrVar.VAR_STAGEPLAYERLISTPOS },
			{ "stage.debugMode", CommonScrVar.VAR_STAGEDEBUGMODE },
			{ "stage.entityPos", CommonScrVar.VAR_STAGEENTITYPOS },

			// Screen Properties
			{ "screen.cameraEnabled", CommonScrVar.VAR_SCREENCAMERAENABLED },
			{ "screen.cameraTarget", CommonScrVar.VAR_SCREENCAMERATARGET },
			{ "screen.cameraStyle", CommonScrVar.VAR_SCREENCAMERASTYLE },
			{ "screen.cameraX", CommonScrVar.VAR_SCREENCAMERAX },
			{ "screen.cameraY", CommonScrVar.VAR_SCREENCAMERAY },
			{ "screen.drawListSize", CommonScrVar.VAR_SCREENDRAWLISTSIZE },
			{ "screen.xcenter", CommonScrVar.VAR_SCREENXCENTER },
			{ "screen.ycenter", CommonScrVar.VAR_SCREENYCENTER },
			{ "screen.xsize", CommonScrVar.VAR_SCREENXSIZE },
			{ "screen.ysize", CommonScrVar.VAR_SCREENYSIZE },
			{ "screen.xoffset", CommonScrVar.VAR_SCREENXOFFSET },
			{ "screen.yoffset", CommonScrVar.VAR_SCREENYOFFSET },
			{ "screen.shakeX", CommonScrVar.VAR_SCREENSHAKEX },
			{ "screen.shakeY", CommonScrVar.VAR_SCREENSHAKEY },
			{ "screen.adjustCameraY", CommonScrVar.VAR_SCREENADJUSTCAMERAY },

			{ "touchscreen.down", CommonScrVar.VAR_TOUCHSCREENDOWN },
			{ "touchscreen.xpos", CommonScrVar.VAR_TOUCHSCREENXPOS },
			{ "touchscreen.ypos", CommonScrVar.VAR_TOUCHSCREENYPOS },

			// Sound Properties
			{ "music.volume", CommonScrVar.VAR_MUSICVOLUME },
			{ "music.currentTrack", CommonScrVar.VAR_MUSICCURRENTTRACK },
			{ "music.position", CommonScrVar.VAR_MUSICPOSITION },

			// Input Properties
			{ "keyDown.up", CommonScrVar.VAR_KEYDOWNUP },
			{ "keyDown.down", CommonScrVar.VAR_KEYDOWNDOWN },
			{ "keyDown.left", CommonScrVar.VAR_KEYDOWNLEFT },
			{ "keyDown.right", CommonScrVar.VAR_KEYDOWNRIGHT },
			{ "keyDown.buttonA", CommonScrVar.VAR_KEYDOWNBUTTONA },
			{ "keyDown.buttonB", CommonScrVar.VAR_KEYDOWNBUTTONB },
			{ "keyDown.buttonC", CommonScrVar.VAR_KEYDOWNBUTTONC },
			{ "keyDown.buttonX", CommonScrVar.VAR_KEYDOWNBUTTONX },
			{ "keyDown.buttonY", CommonScrVar.VAR_KEYDOWNBUTTONY },
			{ "keyDown.buttonZ", CommonScrVar.VAR_KEYDOWNBUTTONZ },
			{ "keyDown.buttonL", CommonScrVar.VAR_KEYDOWNBUTTONL },
			{ "keyDown.buttonR", CommonScrVar.VAR_KEYDOWNBUTTONR },
			{ "keyDown.start", CommonScrVar.VAR_KEYDOWNSTART },
			{ "keyDown.select", CommonScrVar.VAR_KEYDOWNSELECT },
			{ "keyPress.up", CommonScrVar.VAR_KEYPRESSUP },
			{ "keyPress.down", CommonScrVar.VAR_KEYPRESSDOWN },
			{ "keyPress.left", CommonScrVar.VAR_KEYPRESSLEFT },
			{ "keyPress.right", CommonScrVar.VAR_KEYPRESSRIGHT },
			{ "keyPress.buttonA", CommonScrVar.VAR_KEYPRESSBUTTONA },
			{ "keyPress.buttonB", CommonScrVar.VAR_KEYPRESSBUTTONB },
			{ "keyPress.buttonC", CommonScrVar.VAR_KEYPRESSBUTTONC },
			{ "keyPress.buttonX", CommonScrVar.VAR_KEYPRESSBUTTONX },
			{ "keyPress.buttonY", CommonScrVar.VAR_KEYPRESSBUTTONY },
			{ "keyPress.buttonZ", CommonScrVar.VAR_KEYPRESSBUTTONZ },
			{ "keyPress.buttonL", CommonScrVar.VAR_KEYPRESSBUTTONL },
			{ "keyPress.buttonR", CommonScrVar.VAR_KEYPRESSBUTTONR },
			{ "keyPress.start", CommonScrVar.VAR_KEYPRESSSTART },
			{ "keyPress.select", CommonScrVar.VAR_KEYPRESSSELECT },

			// Menu Properties
			{ "menu1.selection", CommonScrVar.VAR_MENU1SELECTION },
			{ "menu2.selection", CommonScrVar.VAR_MENU2SELECTION },

			// Tile Layer Properties
			{ "tileLayer.xsize", CommonScrVar.VAR_TILELAYERXSIZE },
			{ "tileLayer.ysize", CommonScrVar.VAR_TILELAYERYSIZE },
			{ "tileLayer.type", CommonScrVar.VAR_TILELAYERTYPE },
			{ "tileLayer.angle", CommonScrVar.VAR_TILELAYERANGLE },
			{ "tileLayer.xpos", CommonScrVar.VAR_TILELAYERXPOS },
			{ "tileLayer.ypos", CommonScrVar.VAR_TILELAYERYPOS },
			{ "tileLayer.zpos", CommonScrVar.VAR_TILELAYERZPOS },
			{ "tileLayer.parallaxFactor", CommonScrVar.VAR_TILELAYERPARALLAXFACTOR },
			{ "tileLayer.scrollSpeed", CommonScrVar.VAR_TILELAYERSCROLLSPEED },
			{ "tileLayer.scrollPos", CommonScrVar.VAR_TILELAYERSCROLLPOS },
			{ "tileLayer.deformationOffset", CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSET },
			{ "tileLayer.deformationOffsetW", CommonScrVar.VAR_TILELAYERDEFORMATIONOFFSETW },
			{ "hParallax.parallaxFactor", CommonScrVar.VAR_HPARALLAXPARALLAXFACTOR },
			{ "hParallax.scrollSpeed", CommonScrVar.VAR_HPARALLAXSCROLLSPEED },
			{ "hParallax.scrollPos", CommonScrVar.VAR_HPARALLAXSCROLLPOS },
			{ "vParallax.parallaxFactor", CommonScrVar.VAR_VPARALLAXPARALLAXFACTOR },
			{ "vParallax.scrollSpeed", CommonScrVar.VAR_VPARALLAXSCROLLSPEED },
			{ "vParallax.scrollPos", CommonScrVar.VAR_VPARALLAXSCROLLPOS },

			// 3D Scene Properties
			{ "scene3D.vertexCount", CommonScrVar.VAR_SCENE3DVERTEXCOUNT },
			{ "scene3D.faceCount", CommonScrVar.VAR_SCENE3DFACECOUNT },
			{ "scene3D.projectionX", CommonScrVar.VAR_SCENE3DPROJECTIONX },
			{ "scene3D.projectionY", CommonScrVar.VAR_SCENE3DPROJECTIONY },
			{ "scene3D.fogColor", CommonScrVar.VAR_SCENE3DFOGCOLOR },
			{ "scene3D.fogStrength", CommonScrVar.VAR_SCENE3DFOGSTRENGTH },

			{ "vertexBuffer.x", CommonScrVar.VAR_VERTEXBUFFERX },
			{ "vertexBuffer.y", CommonScrVar.VAR_VERTEXBUFFERY },
			{ "vertexBuffer.z", CommonScrVar.VAR_VERTEXBUFFERZ },
			{ "vertexBuffer.u", CommonScrVar.VAR_VERTEXBUFFERU },
			{ "vertexBuffer.v", CommonScrVar.VAR_VERTEXBUFFERV },

			{ "faceBuffer.a", CommonScrVar.VAR_FACEBUFFERA },
			{ "faceBuffer.b", CommonScrVar.VAR_FACEBUFFERB },
			{ "faceBuffer.c", CommonScrVar.VAR_FACEBUFFERC },
			{ "faceBuffer.d", CommonScrVar.VAR_FACEBUFFERD },
			{ "faceBuffer.flag", CommonScrVar.VAR_FACEBUFFERFLAG },
			{ "faceBuffer.color", CommonScrVar.VAR_FACEBUFFERCOLOR },

			{ "saveRAM", CommonScrVar.VAR_SAVERAM },
			{ "engine.state", CommonScrVar.VAR_ENGINESTATE },
			{ "engine.message", CommonScrVar.VAR_ENGINEMESSAGE },
			{ "engine.language", CommonScrVar.VAR_ENGINELANGUAGE },
			{ "engine.onlineActive", CommonScrVar.VAR_ENGINEONLINEACTIVE },
			{ "engine.sfxVolume", CommonScrVar.VAR_ENGINESFXVOLUME },
			{ "engine.bgmVolume", CommonScrVar.VAR_ENGINEBGMVOLUME },
			{ "engine.trialMode", CommonScrVar.VAR_ENGINETRIALMODE },
			{ "engine.deviceType", CommonScrVar.VAR_ENGINEDEVICETYPE },

			// Extras
			{ "screen.currentID", CommonScrVar.VAR_SCREENCURRENTID },
			{ "camera.enabled", CommonScrVar.VAR_CAMERAENABLED },
			{ "camera.target", CommonScrVar.VAR_CAMERATARGET },
			{ "camera.style", CommonScrVar.VAR_CAMERASTYLE },
			{ "camera.xpos", CommonScrVar.VAR_CAMERAXPOS },
			{ "camera.ypos", CommonScrVar.VAR_CAMERAYPOS },
			{ "camera.adjustY", CommonScrVar.VAR_CAMERAADJUSTY },

		// Haptics
			{ "engine.hapticsEnabled", CommonScrVar.VAR_HAPTICSENABLED },
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

			{ "ForEachActive", CommonScrFunc.FUNC_FOREACHACTIVE },
			{ "ForEachAll", CommonScrFunc.FUNC_FOREACHALL },
			{ "next", CommonScrFunc.FUNC_NEXT },

			{ "switch", CommonScrFunc.FUNC_SWITCH },
			{ "break", CommonScrFunc.FUNC_BREAK },
			{ "endswitch", CommonScrFunc.FUNC_ENDSWITCH },

			// Math Functions
			{ "Rand", CommonScrFunc.FUNC_RAND },
			{ "Sin", CommonScrFunc.FUNC_SIN },
			{ "Cos", CommonScrFunc.FUNC_COS },
			{ "Sin256", CommonScrFunc.FUNC_SIN256 },
			{ "Cos256", CommonScrFunc.FUNC_COS256 },
			{ "ATan2", CommonScrFunc.FUNC_ATAN2 },
			{ "Interpolate", CommonScrFunc.FUNC_INTERPOLATE },
			{ "InterpolateXY", CommonScrFunc.FUNC_INTERPOLATEXY },

			// Graphics Functions
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
			{ "SetPaletteEntry", CommonScrFunc.FUNC_SETPALETTEENTRY },
			{ "GetPaletteEntry", CommonScrFunc.FUNC_GETPALETTEENTRY },
			{ "CopyPalette", CommonScrFunc.FUNC_COPYPALETTE },
			{ "ClearScreen", CommonScrFunc.FUNC_CLEARSCREEN },
			{ "DrawSpriteFX", CommonScrFunc.FUNC_DRAWSPRITEFX },
			{ "DrawSpriteScreenFX", CommonScrFunc.FUNC_DRAWSPRITESCREENFX },

			// More Useful Stuff
			{ "LoadAnimation", CommonScrFunc.FUNC_LOADANIMATION },
			{ "SetupMenu", CommonScrFunc.FUNC_SETUPMENU },
			{ "AddMenuEntry", CommonScrFunc.FUNC_ADDMENUENTRY },
			{ "EditMenuEntry", CommonScrFunc.FUNC_EDITMENUENTRY },
			{ "LoadStage", CommonScrFunc.FUNC_LOADSTAGE },
			{ "DrawRect", CommonScrFunc.FUNC_DRAWRECT },
			{ "ResetObjectEntity", CommonScrFunc.FUNC_RESETOBJECTENTITY },
			{ "BoxCollisionTest", CommonScrFunc.FUNC_BOXCOLLISIONTEST },
			{ "CreateTempObject", CommonScrFunc.FUNC_CREATETEMPOBJECT },

			// Player and Animation Functions
			{ "ProcessObjectMovement", CommonScrFunc.FUNC_PROCESSOBJECTMOVEMENT },
			{ "ProcessObjectControl", CommonScrFunc.FUNC_PROCESSOBJECTCONTROL },
			{ "ProcessAnimation", CommonScrFunc.FUNC_PROCESSANIMATION },
			{ "DrawObjectAnimation", CommonScrFunc.FUNC_DRAWOBJECTANIMATION },

			// Music
			{ "SetMusicTrack", CommonScrFunc.FUNC_SETMUSICTRACK },
			{ "PlayMusic", CommonScrFunc.FUNC_PLAYMUSIC },
			{ "StopMusic", CommonScrFunc.FUNC_STOPMUSIC },
			{ "PauseMusic", CommonScrFunc.FUNC_PAUSEMUSIC },
			{ "ResumeMusic", CommonScrFunc.FUNC_RESUMEMUSIC },
			{ "SwapMusicTrack", CommonScrFunc.FUNC_SWAPMUSICTRACK },

			// Sound FX
			{ "PlaySfx", CommonScrFunc.FUNC_PLAYSFX },
			{ "StopSfx", CommonScrFunc.FUNC_STOPSFX },
			{ "SetSfxAttributes", CommonScrFunc.FUNC_SETSFXATTRIBUTES },

			// More Collision Stuff
			{ "ObjectTileCollision", CommonScrFunc.FUNC_OBJECTTILECOLLISION },
			{ "ObjectTileGrip", CommonScrFunc.FUNC_OBJECTTILEGRIP },

			// Bitwise Not
			{ "Not", CommonScrFunc.FUNC_NOT },

			// 3D Stuff
			{ "Draw3DScene", CommonScrFunc.FUNC_DRAW3DSCENE },
			{ "SetIdentityMatrix", CommonScrFunc.FUNC_SETIDENTITYMATRIX },
			{ "MatrixMultiply", CommonScrFunc.FUNC_MATRIXMULTIPLY },
			{ "MatrixTranslateXYZ", CommonScrFunc.FUNC_MATRIXTRANSLATEXYZ },
			{ "MatrixScaleXYZ", CommonScrFunc.FUNC_MATRIXSCALEXYZ },
			{ "MatrixRotateX", CommonScrFunc.FUNC_MATRIXROTATEX },
			{ "MatrixRotateY", CommonScrFunc.FUNC_MATRIXROTATEY },
			{ "MatrixRotateZ", CommonScrFunc.FUNC_MATRIXROTATEZ },
			{ "MatrixRotateXYZ", CommonScrFunc.FUNC_MATRIXROTATEXYZ },
			{ "MatrixInverse", CommonScrFunc.FUNC_MATRIXINVERSE },
			{ "TransformVertices", CommonScrFunc.FUNC_TRANSFORMVERTICES },

			{ "CallFunction", CommonScrFunc.FUNC_CALLFUNCTION },
			{ "return", CommonScrFunc.FUNC_RETURN },

			{ "SetLayerDeformation", CommonScrFunc.FUNC_SETLAYERDEFORMATION },
			{ "CheckTouchRect", CommonScrFunc.FUNC_CHECKTOUCHRECT },
			{ "GetTileLayerEntry", CommonScrFunc.FUNC_GETTILELAYERENTRY },
			{ "SetTileLayerEntry", CommonScrFunc.FUNC_SETTILELAYERENTRY },

			{ "GetBit", CommonScrFunc.FUNC_GETBIT },
			{ "SetBit", CommonScrFunc.FUNC_SETBIT },

			{ "ClearDrawList", CommonScrFunc.FUNC_CLEARDRAWLIST },
			{ "AddDrawListEntityRef", CommonScrFunc.FUNC_ADDDRAWLISTENTITYREF },
			{ "GetDrawListEntityRef", CommonScrFunc.FUNC_GETDRAWLISTENTITYREF },
			{ "SetDrawListEntityRef", CommonScrFunc.FUNC_SETDRAWLISTENTITYREF },

			{ "Get16x16TileInfo", CommonScrFunc.FUNC_GET16X16TILEINFO },
			{ "Set16x16TileInfo", CommonScrFunc.FUNC_SET16X16TILEINFO },
			{ "Copy16x16Tile", CommonScrFunc.FUNC_COPY16X16TILE },
			{ "GetAnimationByName", CommonScrFunc.FUNC_GETANIMATIONBYNAME },
			{ "ReadSaveRAM", CommonScrFunc.FUNC_READSAVERAM },
			{ "WriteSaveRAM", CommonScrFunc.FUNC_WRITESAVERAM },

			{ "LoadFontFile", CommonScrFunc.FUNC_LOADTEXTFONT },
			{ "LoadTextFile", CommonScrFunc.FUNC_LOADTEXTFILE },
			{ "GetTextInfo", CommonScrFunc.FUNC_GETTEXTINFO },
			{ "DrawText", CommonScrFunc.FUNC_DRAWTEXT },
			{ "GetVersionNumber", CommonScrFunc.FUNC_GETVERSIONNUMBER },

			{ "GetTableValue", CommonScrFunc.FUNC_GETTABLEVALUE },
			{ "SetTableValue", CommonScrFunc.FUNC_SETTABLEVALUE },

			{ "CheckCurrentStageFolder", CommonScrFunc.FUNC_CHECKCURRENTSTAGEFOLDER },
			{ "Abs", CommonScrFunc.FUNC_ABS },

			{ "CallNativeFunction", CommonScrFunc.FUNC_CALLNATIVEFUNCTION },
			{ "CallNativeFunction2", CommonScrFunc.FUNC_CALLNATIVEFUNCTION2 },
			{ "CallNativeFunction4", CommonScrFunc.FUNC_CALLNATIVEFUNCTION4 },

			{ "SetObjectRange", CommonScrFunc.FUNC_SETOBJECTRANGE },
			{ "GetObjectValue", CommonScrFunc.FUNC_GETOBJECTVALUE },
			{ "SetObjectValue", CommonScrFunc.FUNC_SETOBJECTVALUE },
			{ "CopyObject", CommonScrFunc.FUNC_COPYOBJECT },
			{ "Print", CommonScrFunc.FUNC_PRINT },

			// Extras
			{ "CheckCameraProximity", CommonScrFunc.FUNC_CHECKCAMERAPROXIMITY },
			{ "SetScreenCount", CommonScrFunc.FUNC_SETSCREENCOUNT },
			{ "SetScreenVertices", CommonScrFunc.FUNC_SETSCREENVERTICES },
			{ "GetInputDeviceID", CommonScrFunc.FUNC_GETINPUTDEVICEID },
			{ "GetFilteredInputDeviceID", CommonScrFunc.FUNC_GETFILTEREDINPUTDEVICEID },
			{ "GetInputDeviceType", CommonScrFunc.FUNC_GETINPUTDEVICETYPE },
			{ "IsInputDeviceAssigned", CommonScrFunc.FUNC_ISINPUTDEVICEASSIGNED },
			{ "AssignInputSlotToDevice", CommonScrFunc.FUNC_ASSIGNINPUTSLOTTODEVICE },
			{ "IsInputSlotAssigned", CommonScrFunc.FUNC_ISSLOTASSIGNED },
			{ "ResetInputSlotAssignments", CommonScrFunc.FUNC_RESETINPUTSLOTASSIGNMENTS },
		};

		private bool IsObjectVar(CommonScrVar? variable)
		{
			return variable.HasValue && variable.Value >= CommonScrVar.VAR_OBJECTENTITYPOS && variable.Value <= CommonScrVar.VAR_OBJECTVALUE47;
		}

		Dictionary<string, string> aliasfix = new Dictionary<string, string>();
		Dictionary<string, MaybeVarRef> objaliases = new Dictionary<string, MaybeVarRef>();
		private string GetVarText(MaybeVarRef varRef, TextWriter writer)
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
						name = name.Replace("object.", "entity.");
					else
						name = name.Replace("object.", "objectList.");
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
				name = name.Replace("object.", "entity->");
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
						case ScriptLineAlias alias:
							string aliasname = alias.Name.Replace('.', '_');
							aliasfix.Add(alias.Name, aliasname);
							if (IsObjectVar(alias.Value.Variable))
								objaliases.Add(alias.Name, alias.Value);
							if (alias.Public)
							{
								writer.Write("#define {0} {1}", aliasname, GetVarText(alias.Value, writer));
								if (!string.IsNullOrEmpty(alias.Comment))
									writer.Write(" //{0}", alias.Comment);
								writer.WriteLine();
							}
							break;
						case ScriptLineValue value:
							if (value.Public)
								writer.WriteLine("extern int {0};", value.Name);
							break;
						case ScriptLineTable table:
							if (table.Public)
								writer.WriteLine("extern int {0}[];", table.Name);
							break;
						case ScriptLineFunction function:
							if (function.Public)
								writer.WriteLine("extern void {0}(struct Entity{1}* entity);", function.Name, typename);
							break;
					}
				writer.WriteLine();
				writer.WriteLine("struct Entity{0}", typename);
				writer.WriteLine("{");
				writer.WriteLine("\tint32 xpos;");
				writer.WriteLine("\tint32 ypos;");
				writer.WriteLine("\tint32 xvel;");
				writer.WriteLine("\tint32 yvel;");
				writer.WriteLine("\tint32 speed;");
				writer.WriteLine("\tint32 values[48];");
				writer.WriteLine("\tint32 state;");
				writer.WriteLine("\tint32 angle;");
				writer.WriteLine("\tint32 scale;");
				writer.WriteLine("\tint32 rotation;");
				writer.WriteLine("\tint32 alpha;");
				writer.WriteLine("\tint32 animationTimer;");
				writer.WriteLine("\tint32 animationSpeed;");
				writer.WriteLine("\tint32 lookPosX;");
				writer.WriteLine("\tint32 lookPosY;");
				writer.WriteLine("\tuint16 groupID;");
				writer.WriteLine("\tuint8 type;");
				writer.WriteLine("\tuint8 propertyValue;");
				writer.WriteLine("\tuint8 priority;");
				writer.WriteLine("\tuint8 drawOrder;");
				writer.WriteLine("\tuint8 direction;");
				writer.WriteLine("\tuint8 inkEffect;");
				writer.WriteLine("\tuint8 animation;");
				writer.WriteLine("\tuint8 prevAnimation;");
				writer.WriteLine("\tuint8 frame;");
				writer.WriteLine("\tuint8 collisionMode;");
				writer.WriteLine("\tuint8 collisionPlane;");
				writer.WriteLine("\tint8 controlMode;");
				writer.WriteLine("\tuint8 controlLock;");
				writer.WriteLine("\tuint8 pushing;");
				writer.WriteLine("\tuint8 visible;");
				writer.WriteLine("\tuint8 tileCollisions;");
				writer.WriteLine("\tuint8 objectInteractions;");
				writer.WriteLine("\tuint8 gravity;");
				writer.WriteLine("\tuint8 left;");
				writer.WriteLine("\tuint8 right;");
				writer.WriteLine("\tuint8 up;");
				writer.WriteLine("\tuint8 down;");
				writer.WriteLine("\tuint8 jumpPress;");
				writer.WriteLine("\tuint8 jumpHold;");
				writer.WriteLine("\tuint8 scrollTracking;");
				writer.WriteLine("\tuint8 floorSensors[5];");
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
						case ScriptLineValue value:
							writer.Write("int {0} = {1};", value.Name, value.Value);
							break;
						case ScriptLineTable table:
							if (table.Size != null)
								writer.Write("int {0}[{1}];", table.Name, table.Size);
							else
								writer.Write("int {0}[] = {{", table.Name);
							break;
						case ScriptLineTableValues tablevalues:
							writer.Write("\t{0},", string.Join(", ", tablevalues.Values));
							break;
						case ScriptLineEndTable _:
							writer.Write("};");
							break;
						case ScriptLineObjectUpdate _:
							writer.Write("void {0}_Update(struct Entity{0}* entity) {{", typename);
							indent += '\t';
							break;
						case ScriptLineObjectDraw _:
							writer.Write("void {0}_Draw(struct Entity{0}* entity) {{", typename);
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
						case ScriptLineForEach _foreach:
							writer.Write("{0}foreach ({1}, {2}, {3}) {{", indent, GetVarText(_foreach.Type, writer), GetVarText(_foreach.Destination, writer), _foreach.Group);
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
								writer.WriteLine("// WARNING: Function {0} does not exist in RSDKv4!", functioncall.Function);
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
									case CommonScrFunc.FUNC_NEXT:
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
