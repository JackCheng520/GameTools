﻿using Game.Core.Util;
using Game.Model.Define;
using Game.Model.PO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace   Game.Util
{
    public class RandomUtil{
        static string[] familyName = {"赵","钱","孙","李","周","吴","郑","王","冯","陈","褚","卫","蒋","沈","韩","杨","朱","秦","尤","许","何","吕","施","张","孔","曹","严","华","金","魏","陶","姜","戚","谢","邹","喻","柏","水","窦","章","云","苏","潘","葛","奚","范","彭","郎","鲁","韦","昌","马","苗","凤","花","方","俞","任","袁","柳","邓","鲍","史","唐","费","廉","岑","薛","雷","贺","倪","汤","藤","殷","罗","毕","郝","邬","安","常","乐","于","时","付","皮","卞","齐","康","伍","余","元","卜","顾","孟","平","黄","和","穆","肖","尹","姚","邵","湛","汪","祁","毛","禹","狄","米","贝","明","藏","计","伏","成","戴","谈","宋","茅","庞","熊","纪","舒","屈","项","祝","董","梁","杜","阮","蓝","闵","席","季","麻","强","贾","路","娄","危","江","童","颜","郭","梅","盛","林","刁","钟","徐","邱","骆","高","夏","蔡","田","樊","胡","凌","霍","虞","万","支","柯","昝","管","卢","莫","经","房","裘","缪","干","解","应","宗","丁","宣","贲","郁","单","杭","洪","包","诸","左","石","崔","吉","钮","龚","程","嵇","邢","滑","裴","陆","荣","翁","荀","羊","惠","甄","曲","家","封","芮","羿","储","靳","汲","邴","糜","松","井","段","富","巫","乌","焦","巴","弓","牧","隗","山","谷","车","侯","宓","蓬","全","郗","班","仰","秋","仲","伊","宫","宁","仇","栾","暴","甘","钭","厉","戎","祖","武","符","刘","景","詹","束","龙","叶","幸","司","韶","郜","黎","蓟","薄","印","宿","白","怀","蒲","邰","从","鄂","索","咸","籍","赖","卓","蔺","屠","蒙","池","乔","阴","胥","能","苍","双","闻","莘","党","翟","谭","贡","劳","逄","姬","申","扶","堵","冉","宰","郦","雍","隙","璩","桑","桂","濮","牛","寿","通","边","扈","燕","冀","郏","浦","尚","农","温","别","庄","晏","柴","瞿","阎","充","慕","连","茹","习","宦","艾","鱼","容","向","古","易","慎","戈","廖","庾","终","暨","居","衡","步","都","耿","满","弘","匡","文","国","寇","广","禄","阙","东","欧","殳","沃","利","蔚","越","夔","隆","师","巩","厍","聂","晁","勾","敖","融","冷","訾","辛","阚","那","简","饶","空","曾","毋","沙","乜","养","鞠","须","丰","巢","关","蒯","相","查","后","荆","红","游","竺","权","逯","盖","益","桓","公","俟","上官","欧阳","夏候","诸葛","闻人","东方","赫连","皇甫","尉迟","公羊","澹台","公冶","宗政","濮阳","淳于","单于","太叔","申屠","公孙","仲孙","轩辕","令狐","钟离","宇文","长孙","慕容","鲜于","闾丘","司徒","司空","亓官","司寇","仉督","子车","颛孙","端木","巫马","公西","漆雕","乐正","壤驷","公良","拓拔","夹谷","宰父","谷梁","楚","晋","闫","法","汝","鄢","涂","钦","段干","百里","东郭","南门","呼延","归海","羊舌","微生","岳","帅","缑","亢","况","有","琴","梁丘","左丘","东门","西门","商","牟","佘","耳","伯","赏","南宫","墨","哈","谯笪","年","爱","阳","佟","第五","言","福"
 };
        static string[] maleTwoName = {"之玉","越泽","锦程","修杰","烨伟","尔曼","立辉","致远","天思","友绿","聪健","修洁","访琴","初彤","谷雪","平灵","源智","烨华","振家","越彬","子轩","伟宸","晋鹏","觅松","海亦","雨珍","浩宇","嘉熙","志泽","苑博","念波","峻熙","俊驰","聪展","南松","问旋","黎昕","谷波","凝海","靖易","芷烟","渊思","煜祺","乐驹","风华","睿渊","博超","天磊","夜白","初晴","瑾瑜","鹏飞","弘文","伟泽","迎松","雨泽","鹏笑","诗云","白易","远航","笑白","映波","代桃","晓啸","智宸","晓博","靖琪","十八","君浩","绍辉","冷安","盼旋","秋白","天德","铁身","老黑","半邪","半山","一江","冰安","皓轩","子默","熠彤","青寒","烨磊","愚志","飞风","问筠","旭尧","妙海","平文","冷之","尔阳","天宇","正豪","文博","明辉","行恶","哲瀚","子骞","泽洋","灵竹","幼旋","百招","不斜","擎汉","千万","高烽","大开","不正","伟帮","如豹","三德","三毒","连虎","十三","酬海","天川","一德","复天","牛青","羊青","大楚","傀斗","老五","老九","定帮","自中","开山","似狮","无声","一手","严青","老四","不可","随阴","大有","中恶","延恶","百川","世倌","连碧","岱周","擎苍","思远","嘉懿","鸿煊","笑天","晟睿","强炫","寄灵","听白","鸿涛","孤风","青文","盼秋","怜烟","浩然","明杰","昊焱","伟诚","剑通","鹏涛","鑫磊","醉薇","尔蓝","靖仇","成风","豪英","若风","难破","德地","无施","追命","成协","人达","亿先","不评","成威","成败","难胜","人英","忘幽","世德","世平","广山","德天","人雄","人杰","不言","难摧","世立","老三","若之","成危","元龙","成仁","若剑","难敌","浩阑","士晋","铸海","人龙","伯云","老头","南风","擎宇","浩轩","煜城","博涛","问安","烨霖","天佑","明雪","书芹","半雪","伟祺","从安","寻菡","秋寒","谷槐","文轩","立诚","立果","明轩","楷瑞","炎彬","鹏煊","幼南","沛山","不尤","道天","剑愁","千筹","广缘","天奇","道罡","远望","乘风","剑心","道之","乘云","绝施","冥幽","天抒","剑成","士萧","文龙","一鸣","剑鬼","半仙","万言","剑封","远锋","天与","元正","世开","不凡","断缘","中道","绝悟","道消","断秋","远山","蓝血","无招","无极","鬼神","满天","飞扬","醉山","语堂","懿轩","雅阳","鑫鹏","文昊","松思","水云","山柳","荣轩","绮彤","沛白","慕蕊","觅云","鹭洋","立轩","金鑫","健柏","建辉","鹤轩","昊强","凡梦","代丝","远侵","一斩","一笑","一刀","行天","无血","无剑","无敌","万怨","万天","万声","万恶","万仇","天问","天寿","送终","山河","三问","如花","灭龙","聋五","绝义","绝山","剑身","浩天","非笑","恶天","断天","仇血","仇天","沧海","不二","碧空","半鬼","文涛","晓刚","洪纲","砖家","叫兽","傀儡","安邦","安福","安歌","安国","安和","安康","安澜","安民","安宁","安平","安然","安顺","安翔","安晏","安宜","安怡","安易","安志","昂然","昂雄","宾白","宾鸿","宾实","彬彬","彬炳","彬郁","斌斌","斌蔚","滨海","波光","波鸿","波峻","波涛","博瀚","博达","博厚","博简","博明","博容","博赡","博涉","博实","博文","博学","博雅","博延","博艺","博易","博裕","博远","才捷","才良","才艺","才英","才哲","才俊","成和","成弘","成化","成济","成礼","成龙","成双","成天","成文","成业","成益","成荫","成周","承安","承弼","承德","承恩","承福","承基","承教","承平","承嗣","承天","承望","承宣","承颜","承业","承悦","承允","承运","承载","承泽","承志","德本","德海","德厚","德华","德辉","德惠","德容","德润","德寿","德水","德馨","德曜","德业","德义","德庸","德佑","德宇","德元","德运","德泽","德明","飞昂","飞白","飞飙","飞掣","飞尘","飞沉","飞驰","飞光","飞翰","飞航","飞翮","飞鸿","飞虎","飞捷","飞龙","飞鸾","飞鸣","飞鹏","飞文","飞翔","飞星","飞翼","飞英","飞宇","飞羽","飞雨","飞语","飞跃","飞章","飞舟","丰茂","丰羽","刚豪","刚洁","刚捷","刚毅","高昂","高岑","高畅","高超","高驰","高达","高澹","高飞","高芬","高峯","高峰","高歌","高格","高寒","高翰","高杰","高洁","高峻","高朗","高丽","高邈","高旻","高明","高爽","高兴","高轩","高雅","高扬","高阳","高义","高谊","高逸","高懿","高原","高远","高韵","高卓","光赫","光华","光辉","光济","光霁","光亮","光临","光明","光启","光熙","光耀","光誉","光远","国安","国兴","国源","冠宇","冠玉","晗昱","晗日","涵畅","涵涤","涵亮","涵忍","涵容","涵润","涵涵","涵煦","涵蓄","涵衍","涵意","涵映","涵育","翰采","翰池","翰飞","翰海","翰翮","翰林","翰墨","翰学","翰音","瀚玥","翰藻","瀚海","瀚漠","昊苍","昊昊","昊空","昊乾","昊穹","昊然","昊天","昊英","浩波","浩博","浩初","浩大","浩宕","浩荡","浩歌","浩广","浩涆","浩瀚","浩浩","浩慨","浩旷","浩阔","浩漫","浩淼","浩渺","浩邈","浩气","浩穰","浩壤","浩思","浩言","和蔼","和安","和璧","和昶","和畅","和风","和歌","和光","和平","和洽","和惬","和顺","和硕","和颂","和泰","和悌","和通","和同","和煦","和雅","和宜","和怡","和玉","和裕","和豫","和悦","和韵","和泽","和正","和志","弘博","弘大","弘方","弘光","弘和","弘厚","弘化","弘济","弘阔","弘亮","弘量","弘深","弘盛","弘图","弘伟","弘新","弘雅","弘扬","弘业","弘义","弘益","弘毅","弘懿","弘致","弘壮","宏伯","宏博","宏才","宏畅","宏达","宏大","宏放","宏富","宏峻","宏浚","宏恺","宏旷","宏阔","宏朗","宏茂","宏邈","宏儒","宏深","宏胜","宏盛","宏爽","宏硕","宏伟","宏扬","宏义","宏逸","宏毅","宏远","宏壮","鸿宝","鸿波","鸿博","鸿才","鸿彩","鸿畅","鸿畴","鸿达","鸿德","鸿飞","鸿风","鸿福","鸿光","鸿晖","鸿朗","鸿文","鸿熙","鸿羲","鸿禧","鸿信","鸿轩","鸿雪","鸿羽","鸿远","鸿云","鸿运","鸿哲","鸿祯","鸿振","鸿志","鸿卓","华奥","华采","华彩","华灿","华藏","华池","华翰","华皓","华晖","华辉","华茂","华美","华清","华荣","华容","嘉赐","嘉德","嘉福","嘉良","嘉茂","嘉木","嘉慕","嘉纳","嘉年","嘉平","嘉庆","嘉荣","嘉容","嘉瑞","嘉胜","嘉石","嘉实","嘉树","嘉澍","嘉禧","嘉祥","嘉歆","嘉许","嘉勋","嘉言","嘉谊","嘉颖","嘉佑","嘉玉","嘉誉","嘉悦","嘉运","嘉泽","嘉珍","嘉祯","嘉志","嘉致","坚白","坚壁","坚秉","坚成","坚诚","建安","建白","建柏","建本","建弼","建德","建华","建明","建茗","建木","建树","建同","建修","建业","建义","建元","建章","建中","经赋","经亘","经国","经略","经纶","经纬","经武","经业","经义","经艺","景澄","景福","景焕","景辉","景龙","景明","景山","景胜","景铄","景天","景同","景曜","君昊","俊艾","俊拔","俊弼","俊才","俊材","俊楚","俊达","俊德","俊发","俊风","俊豪","俊健","俊杰","俊捷","俊郎","俊力","俊良","俊迈","俊茂","俊美","俊民","俊名","俊明","俊楠","俊能","俊人","俊爽","俊悟","俊晤","俊侠","俊贤","俊雄","俊雅","俊彦","俊逸","俊英","俊友","俊语","俊誉","俊远","俊哲","俊喆","俊智","季萌","季同","开畅","开诚","开宇","开济","开霁","开朗","凯安","凯唱","凯定","凯风","凯复","凯歌","凯捷","凯凯","凯康","凯乐","凯旋","凯泽","恺歌","恺乐","康安","康伯","康成","康德","康复","康健","康乐","康宁","康平","康胜","康盛","康时","康适","康顺","康泰","康裕","乐安","乐邦","乐成","乐池","乐和","乐家","乐康","乐人","乐容","乐山","乐生","乐圣","乐水","乐天","乐童","乐贤","乐心","乐欣","乐逸","乐意","乐音","乐咏","乐游","乐语","乐悦","乐湛","乐章","乐正","乐志","黎明","力夫","力强","力勤","力行","力学","力言","立人","立群","良奥","良弼","良才","良材","良策","良畴","良工","良翰","良吉","良骥","良俊","良骏","良朋","良平","良哲","理群","理全","茂才","茂材","茂德","茂典","茂实","茂学","茂勋","茂彦","敏博","敏才","敏达","敏叡","敏学","敏智","明诚","明达","明德","明俊","明朗","明亮","明旭","明煦","明远","明哲","明喆","明知","明志","明智","明珠","朋兴","朋义","彭勃","彭薄","彭湃","彭彭","彭魄","彭越","彭泽","彭祖","鹏程","鹏池","鹏赋","鹏海","鹏鲸","鹏举","鹏鹍","鹏鲲","鹏天","鹏翼","鹏云","鹏运","濮存","溥心","璞玉","璞瑜","浦和","浦泽","奇略","奇迈","奇胜","奇水","奇思","奇邃","奇伟","奇玮","奇文","奇希","奇逸","奇正","奇志","奇致","祺福","祺然","祺祥","祺瑞","琪睿","庆生","锐达","锐锋","锐翰","锐进","锐精","锐立","锐利","锐思","锐逸","锐意","锐藻","锐泽","锐阵","锐志","锐智","睿博","睿才","睿诚","睿慈","睿聪","睿达","睿德","睿范","睿广","睿好","睿明","睿识","睿思","绍钧","绍祺","绍元","升荣","圣杰","思聪","思淼","思源","思博","斯年","斯伯","泰初","泰和","泰河","泰鸿","泰华","泰宁","泰平","泰清","泰然","天材","天成","天赋","天干","天罡","天工","天翰","天和","天华","天骄","天空","天禄","天路","天瑞","天睿","天逸","天元","天韵","天泽","天纵","同方","同甫","同光","同和","同化","同济","巍昂","巍然","巍奕","伟博","伟毅","伟才","伟茂","伟懋","伟彦","伟晔","伟兆","伟志","温纶","温茂","温书","温韦","温文","温瑜","文柏","文昌","文成","文德","文栋","文赋","文光","文翰","文虹","文华","文康","文乐","文林","文敏","文瑞","文山","文石","文星","文宣","文彦","文曜","文耀","文斌","文彬","文滨","向晨","向笛","向文","向明","向荣","向阳","翔宇","翔飞","项禹","项明","心水","心思","心远","欣德","欣嘉","欣可","欣然","欣荣","欣怡","欣怿","欣悦","新翰","新霁","新觉","新立","新荣","新知","信鸿","信厚","信鸥","信然","信瑞","兴安","兴邦","兴昌","兴朝","兴德","兴发","兴国","兴怀","兴平","兴庆","兴生","兴思","兴腾","兴旺","兴为","兴文","兴贤","兴修","兴学","兴言","兴业","兴运","星波","星辰","星驰","星光","星海","星汉","星河","星华","星晖","星火","星剑","星津","星阑","星纬","星文","星宇","星雨","星渊","星洲","修诚","修德","修谨","修筠","修明","修能","修平","修齐","修然","修为","修伟","修文","修雅","修永","修远","修真","修竹","修贤","炫明","学博","学海","学林","学民","学名","学文","学义","学真","雪松","雪峰","雪风","雅昶","雅畅","雅达","雅惠","雅健","雅珺","雅逸","雅懿","雅志","阳飙","阳飇","阳冰","阳波","阳伯","阳成","阳德","阳华","阳晖","阳辉","阳嘉","阳平","阳秋","阳荣","阳舒","阳朔","阳文","阳曦","阳夏","阳旭","阳煦","阳炎","阳焱","阳曜","阳羽","阳云","阳泽","阳州","烨赫","烨然","烨烁","烨烨","烨熠","烨煜","毅然","逸仙","逸明","逸春","宜春","宜民","宜年","宜然","宜人","宜修","意远","意蕴","意致","意智","英飙","英博","英才","英达","英发","英范","英光","英豪","英华","英杰","英朗","英锐","英睿","英叡","英韶","英卫","英武","英悟","英勋","英彦","英耀","英奕","英逸","英毅","英哲","英喆","英卓","英资","英纵","永怡","永春","永安","永昌","永长","永丰","永福","永嘉","永康","永年","永宁","永寿","永思","永望","永新","永言","永逸","永元","永贞","咏德","咏歌","咏思","咏志","勇男","勇军","勇捷","勇锐","勇毅","宇达","宇航","宇寰","宇文","宇荫","雨伯","雨华","雨石","雨信","雨星","玉宸","玉成","玉龙","玉泉","玉山","玉石","玉书","玉树","玉堂","玉轩","玉宇","玉韵","玉泽","元白","元德","元化","元基","元嘉","元甲","元驹","元凯","元恺","元魁","元良","元亮","元明","元青","元思","元纬","元武","元勋","元忠","元洲","苑杰","蕴涵","蕴和","蕴藉","展鹏","哲茂","哲圣","哲彦","振海","振国","正诚","正初","正德","正浩","正平","正奇","正青","正卿","正文","正祥","正信","正雅","正阳","正业","正谊","正真","正志","志诚","志新","志勇","志明","志国","志强","志尚","志专","志文","志行","志学","志业","志义","志用","智明","智鑫","智勇","智敏","智志","智渊","子安","子晋","子民","子明","子墨","子平","子琪","子石","子实","子真","子濯","子昂","子瑜","自明","自强","作人","自怡","自珍","曾琪","泽宇","泽语","文纲","全盛","一立","明刚","广利","明兵","成杲","鞘巧","民尧","子志","珍国","立言","明恩","有刚","天放","城海","家儿","林山","维东","定水","从桐","罗荣","竟泉","庭颂","瑾丁","海咏","臣钊","觐音","欣驹","粤兴","汛络","赞石","甲辰","忡暄","森滕","好翔","廖昭","珈树","序纤","兰北","健贝","化江","卿风","荣淩","云祥","翼锐","源韵","修树","世贝","罕伯","忻循","河根","帅泰","逢侠","余清","君帆","誉珞","翊余","峥凛","建峰","巳保","延晔","童泓","继钦","炳珅","朝言","宽桦","薛仁","斐书","越哲","三澧","月旭","房枫","克晗","翔昊","居浩","敬亚","楗名","浙侯","蒙政","恭和","时颜","言春","福奋","涟树","源嘉","起贝","余艺","林廉","易鸥","袭锐","术仕","稼岭","俨休","攀檬","作尧","发有","舡邱","盼曾","石航","啸琦","书月","岐顶","贝焱","加喜","总岚","渺峰","廷争","厚正","庚希","徽万","咚佩","亚怿","振涛","眧变","励舫","贵成","忻絮","东琥","迪寿","苏石","愉柠","帆粼","中羽","仔城","仲丰","尚鹳","墁字","乐淏","远龙","禹冰","东航","豫镔","瞿勇","刘洋","敏缨","正晗","淮通","本嶙","羽熙","援坝","义轶","华泉","华琨","勰垚","哲恒","星玺","劲雄","琛淦","细烨","泳科","浩韵","裕逾","蒋鑫","虎杰","咏祺","新栋","溢邝","译浚","罗晨","汩远","致厚","峥凯","观霄","攀泰","基铫","坤奥","旻谌","俶太","越标","丞柏","定星","传梁","宇家","羿渡","绎桦","才烨","又尉","延一","汇翰","忠沥","泓玢","民泳","和佟","健谕","熙行","博贝","强愉","坜肃","佑清","磊荞","啸敏","炳逸","乔鲁","初翱","莜咚","着湘","然溟","湉洲","怀安","富文","治军","天宝","厚德","道海","天亮","家新","龙泉","长生","勇明","铁剑","后平","明海","学能","章建","日星","必红","皓洪","荣玮","从为","勃榛","责号","弈涟","健谣","袁联","幼星","子玥","树柏","小潼","楣超","光问","军健","琦慧","杪耒","嘉毛","章容","育剑","必吉","埔塬","桂勋","林鹤","炳禄","体震","前代","佟怀","星发","瞬献","天裴","未宗","招树","跃少","广洲","相岩","绍彦","义学","汉聚","楷钊","彧冕","记阔","北峄","僮朦","轩岐","暖渔","浚同","兴豫","梓臻","宵根","会澄","召昉","勤尘","良严","洪见","增敏","懋活","勋羚","简珺","湛玮","湃非","树壮","庭玖","剑依","卓默","森若","佟骞","生宝","利万","炳施","栋天","沐磬","慕骅","枚钧","眙赫","泽珲","楷昊","施君","点禄","亚博","作焘","炫昶","琦溶","治先","啸乙","慎荣","岚乔","周东","信民","承扁","叮桥","睿逸","肇汐","懋阳","祺敏","玺棂","念依","治汐","刘航","昕沁","宣融","会琦","腊毛","舆烨","诚轩","善望","翔迎","向游","红沐","意计","旻鹏","火城","汩呈","兴晰","常闯","伯敏","自岑","玙梓","品恬","越帆","浩洲","甸册","警忱","源通","奥含","洪旭","当澳","泽良","禹挥","渤旻","曦昌","炯飒","校与","盛明","淩粤","伯录","美德","允醒","淳忆","湘馗","忻键","纪双","赫奋","彦慧","克程","政祝","楦冲","政劭","留画","佳臣","步明","仲修","穹澎","舂珺","滕石","玖庭","慕赫","泉析","含征","勃财","超坤","深贯","珥顺","语有","蜀耕","沄汇","山翀","复斗","实群","粟箬","彰续","筱涛","远赞","泉保","旖春","恩生","盼访","元吉","真百","佳熙","宪群","金建","思宏","乃义","成志","广乐","潮生","晋武","才文","世程","丰年","政举","兴品","洪才","一川","展翅","龙远","溢平","芳辉","增隆","衡杏","廷博","泊燊","展江","京程","严泫","谦致","军驰","毓暄","祎淏","官成","洲袁","矜化","昭郁","智雷","孝桦","弘子","焱冯","强褰","咏双","沐联","昌仙","竟冠","启绒","云力","榛程","举尧","竹贤","寿宣","世枞","十诏","佳羲","冬熙","慈昱","滔甲","舟平","行屿","桓思","纪彦","恪闳","京爨","帧诚","慈意","先宝","来愚","允红","泳红","匡罕","满恒","相献","晋钫","建宽","濯永","昭沩","赫州","剀维","卓力","奎动","檀潮","健华","宓祖","计焕","明明","烨盼","昆刚","臣倪","贤耀","衡茂","斗锟","茂冰","朝森","升棵","支桐","贵潼","孺午","旻涛","训青","啸旌","起辉","楼生","其燠","淮键","辽郴","炙禺","禹尘","耀锟","允州","迩禾","萧瑟","宝逢","哲斌","皓涌","桁仲","曙回","幼镶","勋宽","百南","迎明","士艺","贺定","超培","柯楠","逢果","孔民","学坚","通裕","仁栋","令正","涵琛","晰晖","海起","於融","详功","尔震","浏天","溪善","翔棠","祉琨","广殊","圳兵","昆谳","立材","来棚","剑频","庄选","殊奥","援舰","水鹰","水盛","弘玄","石远","伯铼","益年","科恪","裕伟","毅家","伯喻","春雨","连暄","奚滔","桓贵","宸江","荆裕","澎乔","耕悦","细因","烽漳","壮君","运家","熠桥","羽郅","梓驿","加生","石诺","彭钛","昆楠","柱羿","石栓","永乙","周海","胥冉","泱有","转誉","湉灏","弘理","行兆","沧煜","之存","柯徽","丁忻","品蔚","正乐","箴员","芮百","柘厦","澹田","牧央","正旬","牧冲","之圳","风雨","继成","文健","光德","连生","正高","雨龙","清水","浙江","成显","纬国","海丰","青峰","四海","昌居","文彪","上腾","和明","德传","庭汛","怡承","之安","京由","珅员","拥缔","稀名","湘增","玄言","炎彦","勋润","宸滨","祯亚","炳驿","炫位","旻译","宝朗","则榛","广北","群轩","裔锭","旋坤","八喜","筱坚","纲奇","宾京","宸渤","建榆","扬溶","沛苇","楼凡","超贤","盈美","祥桀","尉斯","柏鸣","禹发","维峻","淄延","羿晖","卫升","与练","登悟","旭应","璞岩","伟宗","万洲","忠本","璐楠","艾垒","总涌","贺在","文松","达皋","怛奕","在囯","华桐","坤能","果俨","付潘","海言","贯与","秋简","明祯","甸嗣","用凯","琪洳","冬旃","小麟","曦坤","沉森","沁金","文平","烁亭","晞汶","燊彰","诩悦","瑾兼","桎沅","枳荞","勇晨","开扬","游颀","晟焙","继现","增廷","列漪","符武","聿军","桄生","树颢","林来","朗桥","润芪","轲赫","徐骧","畅跃","胜轩","德伦","作德","澍菘","光侪","宪允","丛挺","淇雩","加肖","蔚源","客丰","玙珣","棋机"
 };
        static string[] femaleTwoName = { "醉易","紫萱","紫霜","紫南","紫菱","紫蓝","紫翠","紫安","芷天","芷容","芷巧","芷卉","芷荷","之桃","元霜","元绿","元槐","元枫","语雪","语山","语蓉","语琴","语海","语芙","语儿","语蝶","雨雪","雨文","雨梅","雨莲","雨兰","幼丝","幼枫","又菡","友梅","友儿","映萱","映安","迎梦","迎波","易巧","亦丝","亦巧","忆雪","忆文","忆梅","忆枫","以丹","依丝","夜玉","夜梦","夜春","雁荷","雁风","雅彤","雅琴","寻梅","寻冬","雪珍","雪瑶","雪旋","雪卉","笑旋","笑蓝","笑翠","晓亦","晓夏","向梦","香萱","香岚","夏真","夏山","夏兰","惜雪","惜蕊","惜灵","问夏","问蕊","问梅","听筠","听枫","天曼","思松","思菱","水瑶","水彤","书竹","书易","诗桃","诗双","诗珊","诗蕊","山菡","山蝶","若雁","若菱","如风","如冬","如波","秋柔","青雪","青曼","巧蕊","千亦","千柔","千柳","绮琴","绮梅","平萱","平露","沛儿","盼烟","凝雁","凝安","念之","念柏","妙之","妙梦","妙柏","梦之","梦桃","梦琪","梦露","梦凡","曼容","曼荷","曼寒","曼安","绿真","凌文","凌青","凌波","怜阳","怜珊","冷雪","冷荷","乐萱","乐天","乐松","乐枫","静芙","靖柏","寄真","寄文","寄琴","幻天","幻珊","寒天","寒凝","寒梦","寒荷","涵易","涵菱","含玉","含烟","含灵","含蕾","海云","海冬","谷蕊","谷兰","飞珍","飞槐","访云","访烟","访天","访风","凡阳","凡旋","凡梅","凡灵","凡蕾","尔丝","尔柳","尔芙","尔白","孤菱","沛萍","梦柏","从阳","绿海","白梅","秋烟","访旋","元珊","凌旋","依珊","寻凝","幻柏","雨寒","寒安","怀绿","书琴","水香","向彤","曼冬","怜梦","安珊","映阳","思天","初珍","冷珍","海安","从彤","灵珊","夏彤","映菡","青筠","易真","幼荷","冷霜","凝旋","夜柳","紫文","凡桃","醉蝶","从云","冰萍","小萱","白筠","依云","元柏","丹烟","念云","易蓉","青易","友卉","若山","涵柳","映菱","依凝","怜南","水儿","从筠","千秋","代芙","之卉","幻丝","书瑶","含之","雪珊","海之","寄云","盼海","谷梦","雁兰","晓灵","向珊","宛筠","笑南","梦容","寄柔","静枫","尔容","沛蓝","宛海","迎彤","梦易","惜海","灵阳","念寒","采梦","夜绿","又亦","梦山","醉波","慕晴","安彤","半烟","翠桃","书蝶","寻云","冰绿","山雁","南莲","夜梅","翠阳","芷文","南露","向真","又晴","又蓝","雅旋","千儿","听安","凌蝶","向露","从凝","雨双","依白","以筠","含巧","晓瑶","忆山","以莲","冰海","盼芙","冰珍","半双","以冬","千凝","笑阳","香菱","友蕊","若云","天晴","笑珊","凡霜","南珍","晓霜","芷云","谷芹","芷蝶","雨柏","之云","靖巧","寄翠","涵菡","雁卉","涵山","念薇","绮兰","迎蕾","秋荷","代天","采波","诗兰","谷丝","凝琴","凝芙","尔风","觅双","忆灵","水蓝","书蕾","访枫","涵双","初阳","从梦","凝天","秋灵","笑槐","灵凡","冰夏","听露","翠容","绮晴","静柏","天亦","冷玉","以亦","盼曼","乐蕊","凡柔","曼凝","沛柔","迎蓉","映真","采文","曼文","新筠","碧玉","秋柳","白莲","亦玉","幻波","忆之","孤丝","妙竹","傲柏","元风","易烟","怀蕊","寻桃","映之","小玉","尔槐","听荷","赛君","闭月","不愁","羞花","紫寒","夏之","飞薇","如松","白安","秋翠","夜蓉","傲晴","凝丹","凌瑶","初曼","夜安","安荷","青柏","向松","绿旋","芷珍","凌晴","新儿","亦绿","雁丝","惜霜","紫青","冰双","映冬","代萱","梦旋","毒娘","紫萍","冰真","幻翠","向秋","海蓝","凌兰","如柏","千山","半凡","雁芙","白秋","平松","代梅","香之","梦寒","小蕊","慕卉","映梦","绿蝶","凌翠","夜蕾","含双","慕灵","碧琴","夏旋","冷雁","乐双","念梦","静丹","之柔","新瑶","亦旋","雪巧","中蓝","莹芝","一兰","清涟","盛男","凝莲","雪莲","依琴","绣连","友灵","醉柳","秋双","绮波","寄瑶","冰蝶","孤丹","半梅","友菱","飞双","醉冬","寡妇","沛容","南晴","太兰","紫易","从蓉","友易","尔竹","巧荷","寻双","芷雪","又夏","梦玉","安梦","凝荷","外绣","忆曼","不平","凝蝶","以寒","安南","思山","若翠","曼青","小珍","青荷","代容","孤云","慕青","寄凡","元容","丹琴","寒珊","飞雪","妙芙","碧凡","思柔","雁桃","丹南","雁菡","翠丝","幻梅","海莲","宛秋","问枫","靖雁","蛟凤","大凄","傻姑","金连","梦安","碧曼","代珊","惜珊","元冬","青梦","书南","绮山","白桃","从波","访冬","含卉","平蝶","海秋","沛珊","飞兰","凝云","亦竹","梦岚","寒凡","傲柔","凌丝","觅风","平彤","念露","翠彤","秋玲","安蕾","若蕊","灵萱","含雁","思真","盼山","香薇","碧萱","夏柳","白风","安双","凌萱","盼夏","幻巧","怜寒","傲儿","冰枫","如萱","妖丽","元芹","涵阳","涵蕾","以旋","高丽","灭男","代玉","可仁","可兰","可愁","可燕","妙彤","易槐","小凝","妙晴","冰薇","涵柏","语兰","小蕾","忆翠","听云","觅海","静竹","初蓝","迎丝","幻香","含芙","夏波","冰香","凌香","妙菱","访彤","凡雁","紫真","书双","问晴","惜萱","白萱","靖柔","凡白","晓曼","曼岚","雁菱","雨安","谷菱","夏烟","问儿","青亦","夏槐","含蕊","迎南","又琴","冷松","安雁","飞荷","踏歌","秋莲","盼波","以蕊","盼兰","之槐","飞柏","孤容","白玉","傲南","山芙","夏青","雁山","曼梅","如霜","沛芹","丹萱","翠霜","玉兰","汝燕","不乐","不悔","可冥","若男","素阴","元彤","从丹","曼彤","惋庭","起眸","香芦","绿竹","雨真","乐巧","亚男","小之","如曼","山槐","谷蓝","笑容","香露","白薇","凝丝","雨筠","秋尽","婷冉","冰凡","亦云","芙蓉","天蓝","沉鱼","东蒽","飞丹","涵瑶","雁开","以松","南烟","傲霜","香旋","觅荷","幼珊","无色","凤灵","新竹","半莲","媚颜","紫雪","寒香","幼晴","宛菡","采珊","凝蕊","无颜","莫言","初兰","冷菱","妙旋","梨愁","友琴","水蓉","尔岚","怜蕾","怀蕾","惜天","谷南","雪兰","语柳","夏菡","巧凡","映雁","之双","梦芝","傲白","觅翠","如凡","傲蕾","傲旋","以柳","从寒","双双","无春","紫烟","飞凤","紫丝","思卉","初雪","向薇","落雁","凡英","海菡","白晴","映天","静白","雨旋","安卉","依柔","半兰","灵雁","雅蕊","初丹","寒云","念烟","代男","笑卉","曼云","飞莲","幻竹","晓绿","寄容","小翠","小霜","语薇","芷蕾","谷冬","血茗","天荷","问丝","沛凝","翠绿","寒松","思烟","雅寒","以南","碧蓉","绮南","白凡","安莲","访卉","元瑶","水风","凡松","友容","访蕊","若南","涵雁","雪一","怀寒","幻莲","碧菡","绿蕊","如雪","珊珊","念珍","莫英","朝雪","茹嫣","老太","曼易","宛亦","映寒","谷秋","诗槐","如之","水桃","又菱","迎夏","幻灵","初夏","晓槐","代柔","忆安","迎梅","夜云","傲安","雨琴","听芹","依玉","冬寒","绿柏","梦秋","千青","念桃","苑睐","夏蓉","诗蕾","友安","寻菱","绮烟","若枫","凝竹","听莲","依波","飞松","依秋","绿柳","元菱","念芹","如彤","香彤","涵梅","映容","平安","赛凤","书桃","梦松","以云","映易","小夏","元灵","天真","晓蕾","问玉","问薇","笑晴","亦瑶","半芹","幼萱","凡双","夜香","阑香","阑悦","溪灵","冥茗","丹妗","妙芹","飞飞","觅山","沛槐","太英","惋清","太清","灵安","觅珍","依风","若颜","觅露","问柳","以晴","山灵","晓兰","梦菡","思萱","半蕾","紫伊","山兰","初翠","岂愈","海雪","向雁","冬亦","柏柳","青枫","宝莹","宝川","若灵","冷梅","艳一","梦槐","依霜","凡之","忆彤","英姑","清炎","绮露","醉卉","念双","小凡","尔琴","冬卉","初柳","天玉","千愁","稚晴","怀曼","雪曼","雪枫","缘郡","雁梅","雅容","雁枫","灵寒","寻琴","慕儿","雅霜","含莲","曼香","慕山","书兰","凡波","又莲","沛春","语梦","青槐","新之","含海","觅波","嫣然","善愁","善若","善斓","千雁","白柏","雅柏","冬灵","平卉","不弱","不惜","灵槐","海露","白梦","尔蓉","芷珊","迎曼","问兰","又柔","雪青","傲之","绿兰","听兰","冰旋","白山","荧荧","迎荷","丹彤","海白","谷云","以菱","以珊","雪萍","千兰","大娘","思枫","白容","翠芙","寻雪","冰岚","新晴","绿蓉","傲珊","安筠","怀亦","安寒","青丝","灵枫","芷蕊","寻真","以山","菲音","寒烟","易云","夜山","映秋","唯雪","嫣娆","梦菲","凤凰","一寡","幻然","颜演","白翠","傲菡","妙松","忆南","醉蓝","碧彤","水之","怜菡","雅香","雅山","丹秋","盼晴","听双","冷亦","依萱","静槐","冰之","曼柔","夏云","凌寒","夜天","小小","如南","寻绿","诗翠","丹翠","从蕾","忆丹","傲薇","宛白","幻枫","晓旋","初瑶","如蓉","海瑶","代曼","靖荷","采枫","书白","凝阳","孤晴","如音","傲松","书雪","怜翠","雪柳","安容","以彤","翠琴","安萱","寄松","雨灵","新烟","妙菡","雪晴","友瑶","丹珍","白凝","孤萍","寒蕾","妖妖","藏花","葵阴","幻嫣","幻悲","若冰","藏鸟","又槐","夜阑","灭绝","藏今","凌柏","向雪","丹雪","无心","夜雪","幻桃","念瑶","白卉","飞绿","怀梦","幼菱","芸遥","芷波","灵波","一凤","尔蝶","问雁","一曲","问芙","涔雨","宫苴","尔云","秋凌","灵煌","寒梅","灵松","安柏","晓凡","冰颜","行云","觅儿","天菱","舞仙","念真","代亦","飞阳","迎天","摇伽","菲鹰","惜萍","安白","幻雪","友桃","飞烟","沛菡","水绿","天薇","依瑶","夏岚","晓筠","若烟","寄风","思雁","乐荷","雨南","乐蓉","易梦","凡儿","翠曼","静曼","魂幽","茹妖","香魔","幻姬","凝珍","怜容","惜芹","笑柳","太君","莫茗","忆秋","代荷","尔冬","山彤","盼雁","山晴","乐瑶","灵薇","盼易","听蓉","宛儿","从灵","如娆","南霜","元蝶","忆霜","冬云","访文","紫夏","新波","千萍","凤妖","水卉","靖儿","青烟","千琴","问凝","如冰","半梦","怀莲","傲芙","静蕾","艳血","绾绾","绝音","若血","若魔","虔纹","涟妖","雪冥","邪欢","冰姬","四娘","二娘","三娘","老姆","黎云","青旋","语蕊","代灵","紫山","傲丝","听寒","秋珊","代云","代双","晓蓝","茗茗","天蓉","南琴","寻芹","诗柳","冬莲","问萍","忆寒","尔珍","新梅","白曼","一一","安波","醉香","紫槐","傲易","冰菱","访曼","冷卉","乐儿","幼翠","孤兰","绮菱","觅夏","三颜","千风","碧灵","雨竹","平蓝","尔烟","冬菱","笑寒","冰露","诗筠","鸣凤","沛文","易文","绿凝","雁玉","梦曼","凌雪","怜晴","傲玉","幻儿","书萱","绮玉","诗霜","惜寒","惜梦","乐安","以蓝","之瑶","夏寒","丹亦","凌珍","问寒","访梦","新蕾","书文","平凡","如天","怀柔","语柔","宛丝","南蕾","迎海","代芹","巧曼","代秋","慕梅","幼蓉","亦寒","冬易","丹云","丹寒","丹蝶","代真","翠梅","翠风","翠柏","翠安","从霜","从露","初之","初柔","初露","初蝶","采萱","采蓝","采白","冰烟","冰彤","冰巧","傲云","凝冬","雁凡","书翠","千凡","半青","惜儿","曼凡","乐珍","新柔","翠萱","飞瑶","幻露","梦蕊","安露","晓露","白枫","怀薇","雁露","梦竹","盼柳","沛岚","夜南","香寒","山柏","雁易","静珊","雁蓉","千易","笑萍","从雪","书雁","曼雁","晓丝","念蕾","雅柔","采柳","易绿","向卉","惜文","冰兰","尔安","语芹","晓山","秋蝶","曼卉","凝梦","向南","念文","冰蓝","听南","慕凝","如容","亦凝","乐菱","怀蝶","惜筠","冬萱","初南","含桃","语风","白竹","夏瑶","雅绿","怜雪","从菡","访波","安青","觅柔","雅青","白亦","宛凝","安阳","苞络","不二","如花","安安","安吉","安静","安娜","安妮","安琪","安然","安娴","安祯","荌荌","奥婷","奥维","奥雅","北辰","北嘉","北晶","贝莉","贝丽","琲瓃","蓓蕾","碧琳","碧莹","冰冰","冰洁","冰心","冰彦","冰莹","博丽","博敏","博雅","布凡","布侬","布欣","布衣","偲偲","采莲","采薇","彩静","彩萱","彩妍","灿灿","婵娟","畅畅","畅然","唱月","朝旭","朝雨","琛丽","琛瑞","晨曦","晨旭","初然","楚楚","楚洁","楚云","春芳","春华","春娇","春兰","春岚","春梅","春桃","春晓","春雪","春燕","春英","春雨","淳静","淳美","淳雅","慈心","聪慧","聪睿","翠茵","黛娥","丹丹","丹红","丹溪","笛韵","典丽","典雅","蝶梦","丁辰","丁兰","冬梅","端静","端丽","端敏","端雅","端懿","多思","朵儿","婀娜","恩霈","尔雅","璠瑜","方方","方雅","方仪","芳蔼","芳春","芳芳","芳菲","芳馥","芳华","芳蕙","芳洁","芳林","芳苓","芳荃","芳蕤","芳润","芳馨","芳懿","芳茵","芳泽","芳洲","飞燕","菲菲","霏霏","斐斐","芬菲","芬芬","芬馥","丰熙","丰雅","馥芬","甘雨","甘泽","高洁","歌阑","歌云","歌韵","格菲","格格","葛菲","古兰","古香","古韵","谷雪","谷玉","瑰玮","桂帆","桂枫","桂华","桂月","桂芝","海儿","海女","含娇","含景","含文","含香","含秀","晗玥","涵涵","涵韵","菡梅","好洁","好慕","浩岚","浩丽","皓洁","皓月","合乐","合美","合瑞","和璧","和静","和美","和暖","和平","和悌","和煦","和暄","和雅","和怡","和玉","和豫","和悦","河灵","荷珠","荷紫","赫然","鹤梦","姮娥","弘丽","弘雅","弘懿","红豆","红旭","红叶","闳丽","虹星","虹英","虹颖","虹影","虹雨","虹玉","华采","华楚","华乐","华婉","华月","华芝","怀慕","怀思","怀玉","欢欣","欢悦","会雯","会欣","彗云","惠丽","惠美","惠然","惠心","慧婕","慧君","慧丽","慧美","慧心","慧秀","慧雅","慧艳","慧英","慧颖","慧语","慧月","慧云","蕙兰","蕙若","吉帆","吉玟","吉敏","吉欣","吉星","吉玉","吉月","季雅","霁芸","佳惠","佳美","佳思","佳文","佳妍","佳悦","家美","家欣","家馨","嘉宝","嘉惠","嘉丽","嘉美","嘉禾","嘉淑","嘉歆","嘉言","嘉怡","嘉懿","嘉音","嘉颖","嘉玉","嘉月","嘉悦","嘉云","江雪","姣姣","姣丽","姣妍","娇洁","娇然","皎洁","皎月","杰秀","洁静","洁雅","洁玉","今歌","今瑶","今雨","金玉","金枝","津童","锦凡","锦诗","锦文","锦欣","瑾瑶","菁菁","菁英","晶辉","晶晶","晶灵","晶滢","靓影","静安","静涵","静和","静慧","静美","静淑","静恬","静婉","静娴","静秀","静雅","静逸","静云","菊华","菊月","娟娟","娟丽","娟秀","娟妍","绢子","隽洁","隽美","隽巧","隽雅","君洁","君丽","君雅","筠溪","筠心","筠竹","俊慧","俊雅","珺俐","珺琦","珺琪","珺娅","可可","可儿","可佳","可嘉","可心","琨瑶","琨瑜","兰芳","兰蕙","兰梦","兰娜","兰若","兰英","兰月","兰泽","兰芝","岚翠","岚风","岚岚","蓝尹","朗丽","朗宁","朗然","乐然","乐容","乐心","乐欣","乐怡","乐悦","莉莉","丽芳","丽华","丽佳","丽姝","丽思","丽文","丽雅","丽玉","丽泽","丽珠","林帆","林楠","琳芳","琳怡","琳瑜","伶俐","伶伶","灵卉","灵慧","灵秀","灵雨","灵韵","玲琅","玲琳","玲玲","玲珑","玲然","凌春","凌晓","铃语","菱凡","菱华","令慧","令美","流惠","流丽","流如","流婉","流逸","柳思","珑玲","芦雪","罗绮","洛妃","洛灵","玛丽","麦冬","曼丽","曼蔓","曼妮","曼婉","曼吟","曼语","曼珠","嫚儿","蔓菁","蔓蔓","梅风","梅红","梅花","梅梅","梅青","梅雪","梅英","美偲","美华","美丽","美曼","美如","萌阳","蒙雨","孟乐","孟夏","孟阳","梦华","梦兰","梦丝","梦桐","梦影","梦雨","梦月","梦云","梦泽","米琪","米雪","密如","密思","淼淼","妙婧","妙思","妙颜","妙意","妙音","妙珍","玟丽","玟玉","珉瑶","闵雨","敏慧","敏丽","敏叡","敏思","名姝","明煦","明艳","鸣晨","鸣玉","茗雪","茉莉","木兰","牧歌","慕诗","慕思","慕悦","暮雨","暮芸","娜兰","娜娜","乃心","乃欣","囡囡","楠楠","妮娜","妮子","霓云","旎旎","念念","宁乐","凝洁","凝静","凝然","凝思","凝心","凝雪","凝雨","凝远","妞妞","浓绮","暖暖","暖姝","暖梦","盼盼","沛若","佩兰","佩杉","佩玉","佩珍","芃芃","彭丹","嫔然","品韵","平和","平惠","平乐","平良","平宁","平婉","平晓","平心","平雅","平莹","萍雅","萍韵","璞玉","齐敏","齐心","其雨","　奇思","奇文","奇颖","颀秀","琦巧","琦珍","琪华","启颜","绮怀","绮丽","绮美","绮梦","绮思","绮文","绮艳","绮云","千叶","芊丽","芊芊","茜茜","倩丽","倩美","倩秀","倩语","俏丽","俏美","琴心","琴轩","琴雪","琴音","琴韵","卿月","卿云","清昶","清芬","清涵","清华","清晖","清霁","清嘉","清宁","清奇","清绮","清秋","清润","清淑","清舒","清婉","清心","清馨","清雅","清妍","清一","清漪","清怡","清逸","清懿","清莹","清悦","清韵","清卓","情文","情韵","晴波","晴虹","晴画","晴岚","晴丽","晴美","晴曦","晴霞","晴雪","琼芳","琼华","琼岚","琼诗","琼思","琼怡","琼音","琼英","秋芳","秋华","秋露","秋荣","秋彤","秋阳","秋英","秋颖","秋玉","秋月","秋芸","曲静","曲文","冉冉","苒苒","荏苒","任真","溶溶","蓉城","蓉蓉","融雪","柔怀","柔惠","柔洁","柔谨","柔静","柔丽","柔蔓","柔妙","柔淑","柔婉","柔煦","柔绚","柔雅","如心","如馨","如仪","如意","如云","茹薇","茹雪","茹云","濡霈","蕊珠","芮安","芮波","芮欢","芮佳","芮静","芮澜","芮丽","芮美","芮欣","芮雅","芮优","芮悦","瑞彩","瑞锦","瑞灵","瑞绣","瑞云","瑞芝","睿敏","睿思","睿彤","睿文","睿哲","睿姿","润丽","若芳","若华","若兰","若淑","若彤","若英","莎莉","莎莎","三春","三姗","三诗","森莉","森丽","沙羽","沙雨","杉月","姗姗","善芳","善和　","善静","善思","韶华","韶丽","韶美","韶敏","韶容","韶阳","韶仪","邵美","沈靖","沈静","沈然","沈思","沈雅","诗怀","诗文","施然","施诗","世敏","世英","世韵","书慧","书仪","书艺","书意","书语","书云","抒怀","姝好","姝惠","姝丽","姝美","姝艳","淑华","淑惠","淑慧","淑静","淑兰","淑穆","淑然","淑婉","淑贤","淑雅","淑懿","淑哲","淑贞","舒畅","舒方","舒怀","舒兰","舒荣","舒扬","舒云","帅红","双文","双玉","水晶","水悦","水芸","顺慈","顺美","丝柳","丝萝","丝娜","丝琦","丝琪","丝祺","丝微","丝雨","司辰","司晨","思嫒","思宸","思聪","思迪","思恩","思凡","思涵","思慧","思佳","思嘉","思洁","思莲","思琳","思美","思萌","思敏","思娜","思楠","思琪","思若","思思","思彤","思溪","思雅","思怡","思义","思懿","思茵","思莹","思雨","思语","思云","斯琪","斯乔","斯斯","斯文","斯雅","松雪","松雨","松月","素华","素怀","素洁","素昕","素欣","棠华","洮洮","桃雨","陶宁","陶然","陶宜","天恩","天慧","天骄","天籁","天睿","天心","天欣","天音","天媛","天悦","天韵","田然","田田","恬畅","恬静","恬美","恬谧","恬默","恬然","恬欣","恬雅","恬悦","甜恬","湉湉","听然","婷美","婷然","婷婷","婷秀","婷玉","彤蕊","彤彤","彤雯","彤霞","彤云","桐华","桐欣","童彤","童童","童欣","宛畅","宛曼","宛妙","莞尔","莞然","婉慧","婉静","婉丽","婉娜","婉清","婉然","婉容","婉柔","婉淑","婉秀","婉仪","婉奕","菀柳","菀菀","琬凝","琬琰","望慕","望舒","望雅","微澜","微婉","微熹","微月","薇歌","韦曲","韦柔","韦茹","苇然","玮奇","玮琪","玮艺","未央","蔚然","文惠","文静","文君","文丽","文敏","文墨","文姝","文思","文心","文瑶","文漪","文茵","雯华","雯丽","问筠","梧桐","西华","希月","希恩","希慕","希蓉","希彤","惜玉","熙华","熙柔","熙熙","熙阳","熙怡","喜儿","喜悦","霞飞","霞雰","霞辉","霞绮","霞姝","霞文","夏萱","夏璇","夏雪","夏月","仙仪","仙媛","仙韵","闲华","闲静","闲丽","贤惠","贤淑","咸英","娴静","娴淑","娴婉","娴雅","羡丽","献仪","献玉","香洁","香梅","香馨","香雪","湘君","湘灵","湘云","向晨","宵晨","宵雨","宵月","萧曼","萧玉","箫笛","箫吟","小春","小枫","小谷","小楠","小琴","小雯","小星","小瑜","小雨","晓畅","晓枫","晓慧","晓莉","晓楠","晓彤","晓桐","晓星","晓燕","笑雯","笑笑","笑妍","心慈","心菱","心诺","心香","心宜","心怡","心语","心远","忻畅","忻欢","忻乐","忻慕","忻然","忻忻","忻愉","昕昕","欣彩","欣畅","欣合","欣嘉","欣可","欣美","欣然","欣彤","欣笑","欣欣","欣艳","欣怡","欣愉","欣悦","欣跃","莘莘","新洁","新林","新美","新苗","新荣","新文","新雪","新雅","新颖","新雨","新语","新月","歆美","歆然","馨兰","馨荣","馨蓉","馨香","馨欣","杏儿","修洁","修美","修敏","秀华","秀慧","秀杰","秀洁","秀娟","秀隽","秀筠","秀兰","秀丽","秀曼","秀梅","秀美","秀媚","秀敏","秀妮","秀婉","秀雅","秀艳","秀逸","秀英","秀颖","秀媛","秀越","秀竹","绣文","绣梓","琇芳","琇芬","琇晶","琇莹","琇云","轩秀","萱彤","暄和","暄美","暄妍","玄静","玄穆","玄清","玄素","玄雅","璇玑","璇娟","璇珠","璇子","雪冰","雪儿","雪帆","雪翎","雪漫","雪艳","雪羽","寻春","寻芳","雅爱","雅安","雅唱","雅丹","雅凡","雅歌","雅惠","雅洁","雅静","雅隽","雅可","雅丽","雅美","雅楠","雅宁","雅萍","雅韶","雅诗","雅素","雅娴","雅秀","雅艳","雅逸","雅懿","雅云","雅韵","雅致","娅芳","娅静","娅玟","娅楠","娅思","娅童","娅欣","妍芳","妍歌","妍和","妍丽","妍雅","妍妍","芫华","言文","言心","俨雅","琰琬","彦红","彦慧","彦珺","彦灵","彦露","彦杉","彦芝","晏静","晏然","晏如","艳芳","艳卉","艳蕙","燕桦","燕珺","燕岚","燕楠","燕妮","燕婉","燕舞","燕子","阳霁","阳兰","阳曦","阳阳","杨柳","洋然","洋洋","漾漾","瑶岑","瑶瑾","野雪","野云","叶春","叶丹","叶帆","叶芳","叶飞","叶丰","叶吉","叶嘉","叶农","叶彤","叶舞","叶欣","晔晔","一凡","一禾","一嘉","一瑾","一南","一雯","一璇","依美","依楠","依然","依童","依心","仪芳","仪文","宜春","宜嘉","宜楠","宜然","宜欣","怡畅","怡和","怡嘉","怡乐","怡璐","怡木","怡宁","怡然","怡月","怡悦","颐和","颐然","颐真","以欣","以轩","佁然","倚云","忆敏","忆然","忆远","怿悦","奕叶","奕奕","轶丽","逸丽","逸美","逸思","逸馨","逸秀","逸雅","逸云","逸致","茵茵","音华","音景","音仪","音悦","音韵","吟怀","银河","银柳","银瑶","饮香","饮月","胤文","胤雅","英华","英慧","英楠","英秀","英媛","莺莺","莺语","莺韵","瑛琭","瑛瑶","樱花","璎玑","迎秋","盈盈","莹白","莹华","莹洁","莹然","莹琇","莹莹","莹玉","萦怀","萦思","萦心","滢渟","滢滢","颖初","颖慧","颖然","颖馨","颖秀","颖颖","映波","映雪","雍恬","雍雅","优乐","优扬","优悠","优瑗","优悦","攸然","悠柔","悠素","悠婉","悠馨","悠雅","悠奕","悠逸","幼安","幼仪","幼怡","余馥","余妍","愉婉","愉心","瑜蓓","瑜璟","瑜敏","瑜然","瑜英","羽彤","雨彤","雨燕","语冰","语林","语诗","语彤","语心","语燕","玉琲","玉华","玉环","玉瑾","玉珂","玉轩","玉怡","玉英","元英","爰美","爰爰","源源","远悦","媛女","月桂","月华","月朗","月灵","月明","月杉","月桃","月天","月怡","月悦","悦爱","悦畅","悦和","悦恺","悦可","悦来","悦乐","悦人","悦喜","悦心","悦欣","悦宜","悦怡","悦远","悦媛","云淡","云飞","云岚","云露","云梦","云韶","云水","云亭","云蔚","云溪","云霞","云心","云英","芸芸","韫素","韫玉","韵流","韵梅","韵宁","韵磬","韵诗","蕴涵","蕴和","蕴美","蕴秀","赞怡","赞悦","泽恩","泽惠","湛恩","湛芳","湛静","昭懿","昭昭","哲丽","哲美","哲思","哲妍","贞芳","贞静","贞婉","贞怡","贞韵","珍丽","珍瑞","真洁","真如","真茹","真一","真仪","正平","正清","正思","正雅","芝兰","芝英","芝宇","知慧","知睿","芷兰","芷琪","芷若","致欣","致萱","智美","智敏","仲舒","珠佩","珠星","珠轩","珠雨","珠玉","竹筱","竹萱","竹雨","竹月","竹悦","竹韵","庄静","庄丽","庄雅","卓然","卓逸","子爱","子丹","子帆","子凡","子菡","子怀","子惠","子蕙","子琳","子美","子楠","子宁","子舒","子童","子薇","子欣","子萱","子璇","子怡","子亦","子悦","子珍","梓蓓","梓涵","梓洁","梓菱","梓露","梓璐","梓美","梓敏","梓楠","梓倩","梓柔","梓珊","梓舒","梓婷","梓彤","梓童","梓琬","梓欣","梓馨","梓萱","梓瑶","梓莹","梓颖","梓榆","梓玥","梓云","紫蕙","紫琼","紫杉","紫桐","紫薇","紫玉","若雨","静香","梦洁","凌薇","美莲","雪丽","依娜","雅芙","雨婷","晟涵","梦舒","秀影","海琼","雪娴","梦梵","笑薇","瑾梅","晟楠","歆婷","可岚","天瑜","婧琪","媛馨","玥婷","滢心","雪馨","姝瑗","颖娟","歆瑶","凌菲","钰琪","婧宸","靖瑶","瑾萱","佑怡","婳祎","檀雅","若翾","熙雯","语嫣","妍洋","滢玮","沐卉","琪涵","佳琦","伶韵","思睿","清菡","欣溶","菲絮","诗涵","璇滢","静馨","心琪","雅媛","晨芙","婧诗","露雪","蕊琪","舒雅","婉玗","诗茵","静璇","婕珍","婉婷","云薇","霏羽","妍琦","珂玥","茗茶","昭雪","倩雪","玉珍","正梅","美琳","欢馨","优璇","雨嘉","明美","可馨","惠茜","漫妮","香茹","月婵","嫦曦","怡香","韵寒","莉姿","梦璐","灵芸","沛玲","欣妍","曼婷","雪慧","淑颖","钰彤","璟雯","彤萱","梦涵","慧妍","梦婷","雪怡","彦歆","芮涵","婧涵","鑫蕾","希蓝","雪环","慕涵","思蕊","思淼","芮婷","芸熙","婧瑶","沁舒","恨寒","秋春","梦香","春冬","恨荷","翠岚","盼丹","痴旋","寄春","恨之","巧春","友珊","忆柏","秋柏","巧风","恨蝶","春枫","又儿","问香","恨竹","慕蕊","恨云","痴春","孤松","香柳","问春","半香 ","碧巧","寻菡","沛白","平灵","惜香","谷枫","盼旋","幼旋","尔蓝","沛山","代丝","痴梅","觅松","碧春","香桃","安春","靖易","寄灵","采春","初珍 ","恨真","山梅","恨桃","香巧","南蓉","巧兰","寻巧","寄波","念巧","春翠","映阳 ","春柔","忆香","恨天","恨松","问旋","从南","白易","寒雁","怜云","寻文","乐丹","翠柔","谷山","冬儿","春竹","痴梦","晓巧","南春","春雁","从安","怀萍","听白","访琴","绿春","友绿","紫南 ","新巧","冷安","雅阳","南松","诗云","飞风","书芹","幼南","凡梦","尔曼","念波","迎松","青寒","笑天","问安","夜白","灵竹","醉薇","水云","谷波","乐之","笑白","之山","妙海","平夏","向萍","寻南","春文","采绿","天春","平绿","盼香","半雪","山柳","妙春","半安","平春","幼柏","天巧","痴灵","孤风","绮彤","之玉","雨珍","香波","新冬","盼翠","痴香","香柏","巧绿","香春","香莲","香芹","听春","海桃","青香","恨风","春绿","秋白","冰安","南风","醉山","初彤","凝海","香卉","春柏","绿夏","巧春 ","恨瑶","香蝶","盼巧","易容","元柳","半香","秋巧","秋萌","子希","玉琼","云容","琦男","雨瞳","舒锦","宇涵","丹钰","小哲","雪玲","佳晨","源心","思杰","玲伟","如清","钰婷","思行","子蕴","露心","悦沄","升芮","思媛","宁馨","丹婷","青昕","佩芝","琼宇","佳宁","尚萍","思宁","学明","宇玲","姝静","卓尔","子嘉","文芷","思妤","思贤","奕菲","子竹","千芮","欣月","铭雅","子熙","微宁","诗茜","月云","天璐","敏津","思惟","思清","子苏","钰雯","陈茹","玲博","玉晨","悦昀","子馨","晓钰","源思","子鑫","丽菲","秋萍","钰瑶","海娜","宇琳","致雨","书静","瑞哲","怡静","婷超","小佳","暖茹","爱婷","佳琳","子心","倩璐","婷露","美美","小蔚","文歆","文池","秋菲","惟乔","嘉柔","子瑜","修宜","祥芳","尚雪","舒瑶","玥清","璐清","华珊","泺蓉","淑仪","渝茜","清芸","丹蕾","潇娇","泓蓓","美媛","蓓涛","泓蓉","润灵","湘鸿","涵素","清芷","钰岚","润娇","鸿莉","淳芸","治蓓","洁茹","翠燕","治蓉","润瑶","蓓淳","泳兰","莹青","潇葶","祥萍","泳薇","婧珊","洪苇","钰琼","泳婷","芝潇","荧洁","潇圣","蓓淋","涵蓉","健明","慧菲","一曦","雪媛","瀚薇","泳乐","筱梅","潇萍","晨灵","满茹","婧馨","菲琼","浡蓉","湘蓉","文倩","梓惜","艺淑","漩希","淑芹","洲茗","娅莎","柏元","恩婍","柏丹","晓倩","澋蓉","涵菲","静萱","兰熙","溢茹","科予","治莉","钰颖","滢葭","方倩","泳蕴","钰玥","潇蓓","泳葶","映清","雪云","潇蓉","一洋","艺洋","涵莉","芝满","敏雅","瀚葳","丽惠","湘漩","钰婵","洪葶","艺苑","玲花","善莹","丽艳","金娥","瑶洁","培红","傲雪","子瑛","娜拉","淑霞","彩芬","怡瑾","蓝玉","婧怡","百莹","振文","雅悦","悦羽","新红","婵伊","子玲","蓉骊","丹梅","亦媛","瑞莹","莹秀","筱燕","利娟","棕莹","灵玲","颜妍","雯倩","金娟","幼媛","卓悦","娅鸿","慧蓉","巍妍","蘅莹","婷婕","秀欣","素芬","耿冉","晓英","洲玉","满琳","佑文","玲玉","惠媛","琳俏","腹嫣","海莉","小雪","润红","喜文","燕飞","灵玉","青冉","妮怡","建琳","娇瑶","志红","潆文","秀斌","雁萍","细萍","韵萍","韵洁","艳琼","沃颖 ","惠芳","悦琳","瑜玲","岱玉","可琴","叶洁","估倩","知英","媛玲","若怡","倩莹","玲烨","莹丰","恒文","洪萍","净琳","希怡","福英","治文","贻芬","旭文","盛玉","逸妍","莉箐","瑛才","佳佩","月辰","莎婷","天佳","可涵","柳嘉","楚颖","姝慧","钟灵","萌萌","萍玲","明萱","珂玉","以柔","彦彦","钰娇","小岚","佩莹","天宜","于竹","会云","楠倩","钐榳","钐筳","昕颖","晓萌","可苗","琳馨","榳钐","静姝","文萌","婷来","歆彤","阳竹","刘一","天莹","芯珺","茹钐","妤鑫","嘉芝","语茜","琦芳","姝雯","梦妍","天阳","若月","楠萱","桂瑶","阳梦","欣佩","文珺","绚丽","刘依","海欣","姝涵","伟宁","敬姝","斐然","娇柳","闻珈","千筱","楚阳","梦瑶","泗彤","玥如","涵妍","佳璇","珊莉","可意","优若","思莎","明夷","怡如","宛扬","天婷","子学","艺萱","梦一","蓓南","泗桐","嫣笑","梦晨","旖旎","秋奕","菲玲","千明","若晨","雨桐","秋可","怡桥","秋力","秋影","宣虹","盺儒","紫瑶","姝澄","秋垚","书锦","秋园","秋婵","姣柏","珺睿","薇睿","雪梦","秋越","思静","家达","进如","宸澋","秋娅","秋佳","秋倩","怡荣","函乐","秋优","巧芝","元月","仪睿","秋玮","柔鑫","怡净","怡飞","琼芹","秋伊","昕语","元诗","媛菁","丘悦","秋惟","宵穆","思月","秋维","飞舟","书瑾","秋宜","妍菲","秋秋","婉滢","芸慧","秋璐","海佳","柔心","婉莹","怡菲","秋宇","柔伊","邱月","紫丹","怡馨","紫涵","昕雨","怡婧","怡越","红铮","盈霏","奕澄","园月","婷铄","勇龙","秋叶","秋悦","国乐","函涟","朝闻","前俞","美茜","靖荣","宸娆","元怡","思颖","琼菲","芝卓","盺朵","飞霏","薇婷","丘月","盼臻","元亚","姝霏","秋巍","秋逸","炜瑶","紫娢","茹茹","韵涵","雨华","宇佳","雯钰","炜莹","会媛","莉纯","雨菲","焯琳","月倩","茈娢","岚烁","彤琰","芓涵","鑫媛","丽丽","月玲","炜珂","炜萌","雨芬","雨芯","菲慧","月炜","紫菡","籽涵","萌怡","柳媚","月彤","慧慧","彤心","韵彤","炜钰","倩倩","炜仪","莲莲","海婷","娟嘉","若舒","炜诗","婷娜","楚苑","美莹","云云","美瑾","宁子","雪芝","灵茜","咨菡","玲雯","梦琼","苗苗","筠涵","睿涵","海玲","炜歆","媛媛","嘉茹","先飘","桂苑","晓敏","钰媛","梓娢","蕾蕾","茈涵","芓寒","丹媛","芹彤","子涵","蕴菡","灵敏","籽菡","萌雅","韵蕴","姿菡","林韵","彩灵","妙琦","沅彤","炜娴","嘉君","玉玉","芓菡","巧宜","蒙林","浩飞","莉丹","茜欣","茜玮","骁飞","金瑶","丞真","茜玲","茹恒","茜雯","嘉洁","淑玲","雅姌","茹涵","琳菁","婷支","诗雅","颖婷","丽燕","佳婷","颖嘉","文萍","洁晴","云丹","博欣","茜颖","菁怡","嘉仪","亦舒","茜菲","诗家","丹倩","莎祺","若君","淑晴","丽彤","钰林","瑾莲","林佩","茗月","芷瑶","灵然","可梅","莎倩","佳金","智圆","楚怡","茹桁","莎玲","雨青","怡秀","喜芳","喜芬","茜雅","宵騑","思蓓","颖菊","盈珺","述华","康明","雯芝","晓桃","颖菲","羽婷","金欣","承恩","茜璇","伟仪","小茹","诗茗","雅茜","玉珊","伟桢","茜菁","晓宜","茜珊","茜婕","智宁","胜文","淼嘉","婷菁","喜家","云倩","宵非","丹茹","茗心","羽萍","雅臻","佳恩","婷芝","茜芸","荣哲","楚玲","茜琼","梅嘉","雅菲","雯洁","萍馨","详风","萧翡","婷芸","依依","颖宜","萧菲","怡怡","嘉佳","钰柔","雅清","哓飞","惠子","茜綪","莉雅","雪芳","冰菁","娟婧","苏华","诗意","雅昕","茗倩","媛萍","惠芝","梦馨","述萍","静莹","筱茜","茜怡","楚可","喜萌","舒菲","婉如","婷茹","楚琳","楚晓","颖芝","薇羽","林怡","芷妍","苡柔","文涵","茜珂","桂慧","文萱","丽颖","雅苘","金佳","希颖","琦梅","玉婷","茜娜","画诗","华菁","雅菁","雅婕","程洁","新枝","岚菊","嘉莹","惠思","婉芳","萧非","怡若","惠盈","茜倩","茗悦","羽江","金宜","美英","宛芸","茗荔","欣静","锵锵","彬彬","清水","瑶瑛","秋璇","苏真","晓奕","淑智","瑞婵","籁真","仁楣","东梦","允迪","思晨","树瑜","希诗","梓妍","赟真","仁明","佳蔚","仁雯","树璧","楠晨","懿真","诗若","临羡","人芙","婷之","利晓","依苒","茗力","茜凌","希希","霈萱","婷纭","舒萍","清珏","诗莎","芷夏","丹洁","舒茜","芯爱","美佳","扬铃","瑶英","佳涵","淑灵","晨夕","楚馨","智芸","杰晨","佳宜","文芝","锦佳","明嵘","蓓琦","惠杰","沛辰","欢真","媛葶","梓婕","茗家","诗洁","文之","汶妤","宛瑄","静彤","芸真","笔佩","宛玥","仁菲","宛茹","希璟","若馨","清晗","蕴珏","奕屿","桂雯","玺霖","静芝","楚娅","兰馨","淑瑜","卓莹","茗婕","成怡","健琪","佳闻","明梦","博月","雅鑫","海灿","晨玉","清菁","奕凡","雨平","奕敏","健萁","子荷","云鑫","雯梦","奕筎","月雪","雨鑫","清祯","婷萌","雨榳","一琳","雨男","青琰","丽雯","琳菲","雨源","青荔","灵君","钰萍","若文","奕淑","桂菲","惠瑞","清欣","奕佳","清玮","奕辰","雨滔","雨精","清丹","少杰","湄茹","婷涵","昀萍","雯雯","筠萍","清元","红琳","政君","若宁","清昕","英姿","清扬","奕宁","磊磊","佳雨","若香","洁玲","隽馨","清可","炜楠","婷萍","秋涵","婷华","敏惠","梅佩","家莹","夏菲","乐仪","菲雪","美茹","芸嘉","海颖","奕尧","奕君","雪萱","慕雪","依林","雨丹","惠嘉","佩文","雪茹","学茹","奕姝","忆柳","元香","痴珊","恨玉","春儿","寻雁","孤岚","笑霜","盼儿","友巧","恨山","又绿","巧云","平文","青文","翠巧","怀山","寄南","小萍","春海","向山","谷槐","凡巧","香天","夏容","傲冬","谷翠","春蕾","痴瑶","代桃","冷之","盼秋","秋寒","巧夏","海亦","初晴","痴凝","巧香","采南","代巧","痴柏","恨蕊","芷烟","尔阳","怜烟","访儿","觅云","巧","半蕾 "
};
        static string[] maleOneName = {"乞","戾","嵩","邑","瑛","鸿","卿","裘","契","涛","疾","驳","凛","逊","鹰","威","紊","阁","康","焱","城","誉","祥","虔","胜","穆","豁","匪","霆","凡","枫","豪","铭","罡","扬","垣","师","翼","秋","傥","箴","雍","达","乾","鑫","萧","鲂","冥","翰","丑","隶","钧","坤","荆","蹇","骁","沅","剑","勒","筮","磬","戎","翎","函","嚣","炳","耷","惮","鞯","擎","烙","靖","遥","斩","颤","孱","续","岩","奄","博","鹤","绯","匕","奎","仰","霸","乌","邴","败","捕","糜","汲","涔","班","悲","臻","厉","栾","井","伊","储","羿","富","稀","松","寇","碧","珩","靳","鞅","弼","焦","海","刚","纲","囧"
 };
        static string[] femaleOneName = {"姿","芷","芝","筝","真","珍","贞","婴","秀","雯","纹","菀","莞","宛","桐","彤","愫","素","涑","姝","弱","若","蓉","清","青","茗","敏","颦","莆","萍","娩","斓","澜","蓝","兰","惠","荟","涫","芙","璎","姒","苠","淇","绮","雁","襄","紫","芯","沂","衣","荠","莺","萤","怡","苡","悒","荧","茈","香","玲","绫","灵","樱","颜","艳","颖","盈","琦","忻","芸","笙","芳","丝","湘","竺","洙","珠","衫","莛","琳","珊","凤","嫣","芫","葶","芮","沁","柔","妍","芾","莹","斌","瑛","卿","翎","芹"
 };
        private static System.Random random = new System.Random();

        public static bool random1W(int percentage) {
            int result = random.Next(10000) + 1;
            //1 ~ 10000;
            return (result <= percentage);
        }

        
        /// <summary>
        /// 根据权重随机 added by Ly；
        /// </summary>
        /// <param name="percentages"></param>
        /// <returns></returns>
        public static int randomByWeight(List<int> percentages)
        {
            List<Vector2> sections = new List<Vector2>();

            //划分区间；
            int val = 0; int sum = 0; int len = percentages.Count;  
            for (int i = 0;i < len; i++) {
                Vector3 section = new Vector3();
                int percentage  = percentages[i];
                section.x = val;
                section.y = section.x + percentage;
                val      += percentage;
                sum += percentage;
                sections.Add(section);
            }

            //roll
            int rdNum =  getRandomInt(0,sum);

            //查看落到哪个区间内；
            for (int i = 0; i < len; i++) {
                Vector3 section = sections[i];
                if (rdNum >= section.x && rdNum < section.y) {
                    return i;
                }
            }

            return -1;
        }


 
        public static int getRandomInt(int start, int end)
        {
            if (start == end) return start;
            
            if (end < start){
                DebugUtil.log("RandomUtil.getRandomInt: 中参数，end 小于 start");
                return 0;
            }

            //0,10
            int value = start + random.Next(end - start + 1);
            return value;
        }

        public static List<T> randomSortList<T>(List<T> ListT){

            List<T> newList = new List<T>();
            foreach (T item in ListT)
            {
                newList.Insert(random.Next(newList.Count + 1), item);
            }
            return newList;
        }

        public static string buildRndName(int gender)
        {
            string s = null;
            bool isTwo = UnityEngine.Random.Range(1, 3) == 2 ? true : false;
            int rndFamily = UnityEngine.Random.Range(0, familyName.Length);
            int rndName = 0;
            if(gender == GenderType.MALE)
            {
                if (isTwo)
                {
                    rndName = UnityEngine.Random.Range(0, maleTwoName.Length);
                    s = familyName[rndFamily] + maleTwoName[rndName];
                }
                else
                {
                    rndName = UnityEngine.Random.Range(0, maleOneName.Length);
                    s = familyName[rndFamily] + maleOneName[rndName];
                }
            }
            else
            {
                if (isTwo)
                {
                    rndName = UnityEngine.Random.Range(0, femaleTwoName.Length);
                    s = familyName[rndFamily] + femaleTwoName[rndName];
                }
                else
                {
                    rndName = UnityEngine.Random.Range(0, femaleOneName.Length);
                    s = familyName[rndFamily] + femaleOneName[rndName];
                }
            }
            return s;
        }
 
    }
}
