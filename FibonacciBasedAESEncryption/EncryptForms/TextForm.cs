using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FibonacciBasedAESEncryption.EncryptForms
{
    public partial class TextForm : Form
    {
        public MainForm mainForm;
        Color activeColor = MainForm.activeColor;
        Faes faes = MainForm.faes;

        private const string defaultEncryptedFileName = "encrypted";
        //Required for button enabled or disabled
        private byte requiredValues = 3;
        private bool keyOkay = false;
        private bool folderOkay = false;
        private bool textOkay = false;

        public TextForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            //Initialize radio buttons: method_encrypt and encType_text
            rb_method_encrypt.Checked = rb_encType_text.Checked = true;
            rb_method_encrypt.ForeColor = rb_encType_text.ForeColor = activeColor;

            //Initialize lbl_key_info
            lbl_key_info.Text = "";
            lbl_key_info.Visible = false;
            FormCommonEvents.HorizontalCenter(new List<Control> { lbl_key, tb_key, lbl_key_info });

            //Set placeholder to filename
            FormCommonEvents.SendMessage(
                tb_filename.Handle,
                FormCommonEvents.EM_SETCUEBANNER,
                0,
                defaultEncryptedFileName
            );

            //Disable the encrypt button
            btn_encrypt.Enabled = false;

            //Add common events for passing required params
            this.FormClosing += (object s, FormClosingEventArgs ee) => FormCommonEvents.HanderFormClosing(s, ee, this.mainForm);
            this.tb_key.TextChanged += (object s, EventArgs ee) =>
            {
                FormCommonEvents.HandlerTbKeyTextChanged(s, ee, lbl_key, lbl_key_info);
                if (tb_key.Text.Length == faes.bytesForKey)
                {
                    if (!keyOkay)
                    {
                        keyOkay = true;
                        if(--requiredValues == 0)
                            btn_encrypt.Enabled = true;
                    }
                }
                else if (keyOkay)
                {
                    keyOkay = false;
                    requiredValues++;
                    btn_encrypt.Enabled = false;
                }
            };
            this.tb_key.Enter += (object s, EventArgs ee) => FormCommonEvents.HandlerTbKeyTextEnter(s, ee, lbl_key, lbl_key_info);
            this.tb_key.KeyPress += (object s, KeyPressEventArgs ee) => FormCommonEvents.HandlerTbKeyPress(s, ee, lbl_key, lbl_key_info);
            this.tb_key.Leave += (object s, EventArgs ee) => FormCommonEvents.HandlerTbKeyLeave(s, ee, lbl_key, lbl_key_info);
            this.tb_key.KeyDown += FormCommonEvents.HandlerTbKeyDown;


//            //For Test
//            tb_key.Text = "AhmetEmsalCipher";
//            vistaFolderBrowserDialog1.SelectedPath = @"D:\Kullanıcılar\Ahmet\KYK Burs";
//            tb_text.Text = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec diam lacus, auctor eu tellus eu, porttitor sodales eros. Cras tempus lobortis malesuada. Praesent ac consectetur diam, vitae posuere metus. Aliquam eleifend, purus vel commodo porttitor, tortor nunc rhoncus odio, sit amet semper dui erat rhoncus ante. Curabitur id est vestibulum, vestibulum dui nec, pretium erat. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed eu placerat nibh.

//Phasellus malesuada odio nec risus aliquam, eget venenatis enim varius. Integer magna nisi, ultricies sed elementum nec, pharetra eu elit. Nulla ante nibh, rutrum id justo vitae, ornare sollicitudin ligula. Ut vel ullamcorper elit. Proin aliquam lorem ac augue feugiat bibendum. Sed ac suscipit sapien, eget ullamcorper metus. Etiam eleifend nulla non augue egestas, vitae hendrerit risus consequat. Sed iaculis, turpis vel consequat finibus, mauris dui laoreet metus, euismod maximus mi ex in dolor. Quisque nulla est, congue vel enim vitae, convallis elementum libero. Integer non condimentum justo, ac laoreet nulla.

//Curabitur sed elementum quam. Aliquam congue congue faucibus. Nullam turpis dui, tincidunt in pulvinar vitae, rhoncus a massa. Nulla in ante pretium, mollis sapien at, gravida nulla. Donec laoreet elit eget blandit maximus. Fusce lacinia augue eu ante tristique mollis. Integer vel mollis dolor. Donec posuere sapien a ultrices pretium. Proin non malesuada felis. Cras dictum ligula eget mi cursus, vel aliquet turpis mattis. Sed vel enim ut turpis fermentum porta. Morbi suscipit, nunc a tempus tincidunt, sem metus viverra ex, a varius ex magna tristique dui. Nunc efficitur maximus porttitor. Morbi eget fringilla nibh. Duis venenatis viverra consequat.

//Fusce mattis sollicitudin tortor, ut vehicula velit iaculis non. Nullam ac lacus vitae elit iaculis venenatis. Integer dictum augue tellus, vel varius sapien placerat ac. Pellentesque viverra, velit sed malesuada semper, neque felis maximus enim, a viverra diam dolor in ex. Quisque at leo turpis. Nullam blandit et elit a dapibus. Fusce fringilla ullamcorper enim non malesuada. Phasellus nec quam semper, efficitur magna vitae, posuere elit. In maximus convallis sapien, ut finibus augue ornare id. Mauris congue purus a ante mattis, eget luctus felis convallis. Sed at congue risus, non lacinia lorem. Pellentesque dui lectus, luctus in nibh quis, dictum tempor massa.

//In id porttitor metus. Morbi lobortis, mi eu fringilla lobortis, lectus ante faucibus justo, id auctor elit neque eget lacus. Proin ut turpis eu justo dignissim varius. Integer vel orci eget nunc rhoncus vestibulum vitae nec dolor. In metus metus, bibendum vel mauris at, elementum molestie diam. Fusce quis blandit tellus. Donec ac pellentesque purus, in sagittis felis. Cras in nunc non erat tristique eleifend. Mauris lobortis gravida lectus, sed consequat sapien pellentesque et. Sed eget fringilla nulla, laoreet venenatis ligula. In finibus turpis at elementum fermentum. Praesent consequat libero enim, eu venenatis ex sollicitudin quis. Nulla sit amet libero placerat, mollis dui in, aliquam lorem. Nam nisl mauris, sodales id enim id, pretium pharetra ante.

//Mauris accumsan iaculis libero. Pellentesque gravida odio egestas, feugiat nibh ac, aliquet arcu. Praesent id eros a est interdum convallis quis ut mauris. In rutrum sapien vitae pretium fringilla. Ut at vulputate lacus, nec fringilla nibh. In dui urna, vestibulum ac consectetur eget, suscipit ut lacus. Sed id nisl risus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Curabitur a nunc eget nibh lacinia malesuada. Integer pharetra vel eros ut cursus. Aenean a congue orci, vel imperdiet ex. Integer vulputate congue leo at ultrices. Suspendisse convallis tristique eros sit amet laoreet.

//Quisque sollicitudin, nulla et elementum accumsan, risus dui porta dui, et mattis nunc lorem id eros. Praesent vestibulum tristique lectus, vitae vehicula magna. Sed auctor, neque egestas vulputate pellentesque, ligula dui congue ante, ac ornare risus nunc a est. Praesent venenatis pellentesque orci feugiat elementum. Nam sit amet nisi sit amet leo ultrices volutpat id et eros. Nullam ut turpis sem. Ut sapien ligula, tempor sed accumsan et, tempus luctus magna. Cras purus diam, pellentesque at faucibus ullamcorper, dapibus id ligula. Suspendisse blandit quis elit sit amet tincidunt. Donec lorem dui, porttitor vitae nibh non, gravida efficitur ex. Maecenas convallis, mi nec facilisis varius, turpis neque porttitor odio, ut vestibulum tellus turpis gravida lacus. Sed id neque non est dignissim finibus. Praesent vestibulum, massa eu pulvinar dictum, massa tortor lobortis nulla, nec efficitur ligula ante nec sem. In accumsan nibh justo, quis tincidunt orci posuere in. Ut maximus accumsan erat sit amet imperdiet. In nec posuere ex.

//Nulla elementum interdum metus, eu porttitor sem cursus et. Cras nisi justo, feugiat sed lorem ac, pulvinar convallis lacus. Quisque accumsan auctor nulla eu tempus. Vestibulum ut elit non ante consectetur suscipit. Nullam interdum pharetra porta. Nam tincidunt massa vel mi ultrices, et condimentum lectus mattis. Mauris commodo accumsan libero et porttitor. Sed volutpat dapibus ipsum, sed sagittis lacus molestie vitae.

//Aliquam id sollicitudin enim. Phasellus cursus, lectus eget placerat congue, lorem nunc malesuada metus, non posuere quam nibh et mauris. Vestibulum consectetur tellus et leo facilisis varius. Sed ultricies tempor massa ac bibendum. Sed vel erat placerat metus finibus faucibus eu et risus. Integer quis tempus diam, eget faucibus urna. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis sed facilisis diam. Sed quis mollis purus. Aliquam vel ultrices nisl. Mauris dictum porta laoreet.

//Nunc cursus imperdiet dui vitae posuere. Pellentesque nec lectus nulla. Duis eget condimentum erat. Proin id tincidunt ipsum, ut feugiat tellus. Vestibulum rutrum varius dignissim. Vivamus laoreet risus non elit faucibus, vitae iaculis turpis sagittis. Cras a imperdiet felis. Nulla lacinia semper turpis vel aliquam. Suspendisse imperdiet condimentum ante a iaculis. Cras erat mauris, pharetra vitae dictum at, vestibulum vehicula leo. Proin porttitor blandit est vitae venenatis. Suspendisse potenti. Nulla iaculis commodo metus, ac luctus est facilisis at.

//Donec consectetur lorem sed gravida tempor. Sed sagittis ac purus dictum maximus. Ut eget orci leo. Ut et auctor massa. Sed ac sapien est. Donec vestibulum finibus ex, nec interdum mi consequat vitae. Aliquam faucibus metus ante, at rutrum nisi mollis id. Nunc justo lectus, rhoncus vel tempus at, condimentum in sapien. Sed justo sapien, gravida vitae posuere non, ullamcorper non leo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Etiam et massa velit. Fusce egestas et mauris quis gravida. In vel mattis tortor.

//Etiam malesuada nisi bibendum sodales sodales. In hac habitasse platea dictumst. Suspendisse velit dolor, vehicula at nulla quis, placerat cursus odio. Proin ac pharetra eros. Nunc pretium dolor sed justo blandit, vel tristique lacus efficitur. Proin eget facilisis erat. Sed auctor nisl in magna egestas, commodo dapibus quam mattis. Cras commodo pulvinar ligula, consequat scelerisque nunc finibus vel. Proin quis gravida tellus.

//Cras consequat posuere risus eget dapibus. Suspendisse venenatis egestas nisi non dapibus. Donec condimentum, odio eu aliquet congue, enim dolor malesuada lectus, a ullamcorper orci velit at quam. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer tempor ullamcorper pulvinar. Curabitur id feugiat leo. Mauris condimentum odio enim, at fringilla dui aliquam vitae. Nulla facilisi. Vestibulum nunc augue, lobortis in turpis at, ultricies fringilla neque. Morbi ut ipsum aliquet, semper magna sed, sollicitudin dui. Suspendisse imperdiet sem eget arcu volutpat, a posuere quam suscipit. Ut rutrum neque eget tellus condimentum, non interdum odio dignissim. Nunc auctor pretium diam.

//Nunc ut semper leo. Proin feugiat lacinia diam, ullamcorper porttitor massa placerat non. Nunc consectetur sapien sit amet ipsum sodales, vitae ornare lacus lacinia. Duis fringilla ex ut augue lobortis pulvinar. Cras maximus iaculis euismod. Proin ut orci vel sem pellentesque hendrerit. Integer mollis erat eget neque aliquam, pulvinar tempus ante suscipit. Sed massa libero, condimentum placerat facilisis sed, molestie sed nisi. Aliquam a tellus feugiat, egestas lectus in, elementum magna. Suspendisse tristique, tortor sit amet porta eleifend, justo dui dignissim massa, at placerat mi ante eget odio.

//Etiam ullamcorper dui sed sem viverra tempus. Morbi auctor dolor massa, et hendrerit odio dictum eget. Praesent iaculis tincidunt eros, sit amet imperdiet elit dictum at. Donec accumsan eu ante quis venenatis. Aliquam auctor magna in urna iaculis, in iaculis quam lobortis. Fusce a magna felis. Nulla et consequat sem. In egestas, ex vel finibus egestas, diam ipsum iaculis eros, quis bibendum libero nisl ut urna. Donec elementum quis risus sit amet dapibus. Pellentesque consectetur vehicula mollis.

//Donec urna diam, bibendum vel nibh a, sodales efficitur eros. Curabitur sit amet dui vel tellus suscipit pulvinar. Duis id urna vel leo congue tempor quis a odio. Aliquam a erat in tellus ullamcorper porttitor vel in diam. Nulla facilisi. Nulla placerat erat ac mauris convallis tincidunt. Donec at ligula at neque ultrices convallis quis quis quam. Vivamus molestie viverra diam, in mattis ex consequat a. In semper nisl a egestas aliquam. Praesent commodo viverra magna, at tristique orci dictum eget. Vestibulum eu tempor ex. Vivamus imperdiet eleifend blandit. Donec vel leo vitae urna bibendum finibus a sed tortor. Pellentesque augue nunc, tincidunt eget rutrum non, ornare eu nibh. Phasellus sit amet iaculis ipsum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;

//In hac habitasse platea dictumst. Pellentesque vel nisi at quam varius congue ac vel metus. Nam ac consectetur mi. Praesent sagittis enim orci, eu sollicitudin nulla vestibulum sit amet. Vestibulum sit amet malesuada odio. Integer ac ultrices ligula. Proin semper risus nec lacinia hendrerit. Maecenas sit amet interdum felis. Morbi pharetra nisl ut mauris commodo, ut imperdiet augue tempor. In erat diam, fermentum vel venenatis vitae, suscipit eu sem. Pellentesque vel auctor diam. Maecenas vestibulum neque ultrices, egestas nisl vel, ultrices ante. Quisque consectetur bibendum risus, non auctor diam euismod quis. Vivamus ac felis orci. Sed hendrerit ultricies tellus. Mauris leo nisl, rhoncus eu massa at, auctor dapibus dui.

//Morbi luctus eros eu magna dignissim, at lobortis ligula imperdiet. Nullam sit amet tellus eros. Etiam eu dui et magna venenatis molestie vel id sapien. Integer hendrerit fermentum convallis. In et arcu eleifend, lacinia nunc pretium, tempus augue. Proin vitae sagittis sapien, in varius diam. Nullam sodales auctor nunc ut placerat. Maecenas nec interdum felis. Vivamus tincidunt tempor quam ac tempus. Donec sit amet diam vel dui mollis convallis. Maecenas rhoncus magna sed purus eleifend pellentesque. Phasellus in aliquet nulla. Donec a tortor nec mi tincidunt pellentesque. In vel pulvinar erat.

//Cras consequat nulla a accumsan faucibus. Praesent sodales laoreet ligula, ac vehicula augue dignissim quis. Sed a posuere risus, nec euismod felis. Fusce tortor elit, gravida sed convallis sollicitudin, gravida quis tellus. Ut varius consequat dapibus. Morbi placerat, eros vitae pellentesque fringilla, mi ex mattis justo, quis suscipit ligula magna et nisl. Proin at luctus diam. Integer mi felis, ultricies at ex eget, fringilla tincidunt augue. Donec eget mollis urna. Integer dolor nisl, pellentesque eget consequat in, aliquet id enim. Sed non nulla feugiat, laoreet nisl ac, convallis turpis. Curabitur nulla nisi, feugiat varius vestibulum sit amet, feugiat vel dolor. Praesent eu nulla felis.

//Ut interdum sed sem a consequat. Etiam vitae accumsan turpis. Vivamus sed sodales mi. Nullam nec neque odio. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Fusce dapibus ante id massa gravida, et ullamcorper nibh elementum. Praesent nec egestas metus. Duis et augue ligula. Pellentesque commodo tincidunt sollicitudin. Integer in eros finibus, facilisis lectus vel, mollis mi. Vivamus et tellus ipsum. Mauris sodales consectetur ipsum, ut euismod eros varius ac. Suspendisse quis consequat ipsum. Donec a mattis tellus. Nulla interdum eleifend libero, a efficitur purus dapibus pharetra.

//Proin eu dolor diam. Curabitur ut arcu condimentum libero vestibulum bibendum eget a enim. Mauris lectus nisl, tincidunt a ornare id, mollis id ligula. Aliquam id posuere nunc, in dignissim lectus. Integer varius mi lectus, id mattis nibh elementum vitae. Nullam malesuada cursus libero eu dignissim. Aliquam tempor scelerisque nulla, at viverra leo. Curabitur id quam vitae risus hendrerit congue. Vivamus vitae felis justo. Etiam arcu leo, lacinia a fringilla vitae, aliquam quis dui. Morbi ac mi aliquet, varius nulla sit amet, ornare ipsum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.

//Nullam ultrices leo lacus, ut congue sapien volutpat vitae. Nulla facilisi. Suspendisse potenti. Curabitur malesuada quis diam blandit dapibus. Integer et maximus nunc. Phasellus in tristique urna, at euismod nisl. Duis quis diam ut tortor elementum pretium. Suspendisse malesuada facilisis purus a placerat. Integer facilisis non urna vel ornare.

//Nam scelerisque quam ligula, at consequat nunc placerat quis. Morbi nec laoreet justo, sit amet volutpat ligula. Nam erat risus, gravida at egestas quis, dapibus sit amet mi. Vivamus nec pulvinar felis. Curabitur mattis facilisis nunc, vel laoreet libero fermentum in. Nulla vestibulum tellus sed dui malesuada laoreet. Etiam a laoreet diam. Praesent id nulla lorem. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Praesent at scelerisque massa. Sed ac ultricies tellus. In non suscipit mauris. Nulla condimentum velit sit amet nulla venenatis, id viverra risus posuere. Nam iaculis egestas lacinia. Nulla facilisi. Sed laoreet hendrerit lacus, non ornare sapien bibendum a.

//Fusce vestibulum sagittis nisi a luctus. Sed lobortis velit ac ipsum commodo facilisis. Aliquam lacus dolor, volutpat et placerat non, placerat eget velit. Ut porta tempor est, id dignissim quam consequat at. Praesent id felis nulla. Morbi imperdiet arcu lectus, ac congue ipsum volutpat a. Vestibulum pretium porta felis ut rutrum. Fusce sit amet lacus ultricies leo laoreet consequat vitae et metus. Duis sed maximus diam. Quisque at erat quis purus lobortis feugiat ac nec neque. Maecenas id est neque. Mauris condimentum aliquam arcu. Integer ullamcorper eget nunc vel aliquam. Praesent sed lacus et odio viverra tincidunt.

//Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Fusce eget nunc suscipit, elementum diam ac, suscipit felis. Proin id eros eu mi maximus commodo. Nam justo arcu, dapibus id ipsum nec, vehicula bibendum ex. Duis interdum consectetur neque nec vehicula. Vestibulum porta lectus ante, a condimentum mi vestibulum in. Suspendisse malesuada, nisi in feugiat viverra, lacus odio gravida ante, sed molestie nisl ante quis velit. Mauris vel placerat nunc. Vivamus posuere non nisl sed elementum. Aliquam erat volutpat. Cras id porta urna, sit amet pretium turpis. Aliquam sit amet malesuada lacus. Cras ligula ex, malesuada id nisl in, feugiat pulvinar augue. Integer volutpat est nec diam laoreet aliquet. Aenean lobortis neque ac molestie feugiat.

//Duis non diam sed libero porttitor maximus pharetra ac mauris. Etiam non pretium eros. Ut dictum urna vitae scelerisque pretium. Vivamus in quam interdum, interdum tortor eget, ultricies ex. Nunc sed vehicula metus. Sed tortor lacus, finibus quis maximus eu, aliquam eu tortor. Morbi vel pulvinar ante. Sed elementum iaculis ullamcorper. Sed mollis vitae diam laoreet elementum. Donec aliquet, risus ultricies elementum laoreet, nisl lectus vestibulum risus, in porta quam lorem imperdiet massa. Integer tempor id justo quis hendrerit. Fusce viverra massa est, quis luctus urna posuere et. In consequat euismod lectus, vel fermentum tellus.

//Morbi congue, eros sit amet scelerisque ultricies, eros nunc malesuada neque, eu porta metus leo id tellus. Sed condimentum, quam eu gravida faucibus, metus arcu vulputate mi, nec egestas nunc diam at velit. Donec feugiat eu metus ac scelerisque. Phasellus sit amet euismod velit. Ut egestas luctus malesuada. Curabitur lacinia ipsum nec nibh interdum feugiat. Maecenas placerat sem et ligula convallis, vel porttitor ex volutpat. Donec sit amet fermentum metus. Donec nunc urna, blandit id accumsan sed, scelerisque ut leo. Integer velit neque, fringilla at velit eget, auctor laoreet arcu. Proin pharetra sit amet ex nec consequat. Mauris sagittis dui odio, eu eleifend neque facilisis vitae.

//Ut sit amet nisi at nisi varius luctus. Sed tincidunt volutpat diam, eget egestas erat viverra in. Aenean quis mattis mauris, non venenatis nibh. Phasellus luctus convallis efficitur. Integer et nulla tortor. Proin sed odio vitae ante mattis placerat ac non magna. Aenean a purus lacus. Donec vulputate ipsum a quam semper euismod nec a elit. Nunc augue ante, pellentesque eget molestie quis, molestie eu nisl. Nulla eleifend sit amet libero eu ultrices. Proin cursus nibh dui, ut viverra felis mattis a. Mauris lobortis sem vel nulla cursus bibendum. Nam felis nunc, scelerisque vel pulvinar non, elementum vitae urna. Ut mattis mi eget velit eleifend, et ultricies ex finibus.

//Praesent interdum ipsum at tortor faucibus, dignissim accumsan massa luctus. Nam convallis tortor viverra, ornare erat nec, imperdiet est. Aliquam erat volutpat. Phasellus ligula lectus, scelerisque nec mauris sed, fermentum sodales velit. Proin sit amet mi vehicula, pulvinar augue ac, blandit metus. Aliquam finibus, massa in pellentesque vehicula, ante metus molestie dolor, a accumsan dolor justo et ipsum. Duis sed justo justo. Vivamus interdum massa id lacus elementum, at ornare leo sodales. Vivamus laoreet justo lorem, sed rutrum nulla fermentum vitae. Phasellus erat ipsum, hendrerit ac semper non, scelerisque nec sapien. Sed blandit risus ac ipsum varius, vel venenatis nisi laoreet. Cras at ornare felis.

//Sed facilisis, eros vitae molestie tempus, quam ex gravida est, eget varius lorem justo et quam. Cras efficitur rutrum nisl, at aliquam risus commodo id. Donec sed libero in neque iaculis tincidunt id eget neque. Integer non tempor ipsum, ut mollis sapien. Nullam eu dui non ligula ornare dignissim. Nam massa nisl, accumsan non suscipit sed, efficitur in diam. Integer fringilla facilisis enim id ullamcorper. Duis lorem tortor, vulputate ac sem et, efficitur condimentum sapien. Aenean in est at orci cursus efficitur at id purus. Aenean aliquet neque justo, id sagittis libero lobortis id. Fusce quis ligula erat.

//Mauris pellentesque consequat velit, eget eleifend dui pretium sit amet. Suspendisse mattis tristique ipsum quis accumsan. Sed facilisis dolor nunc, id consequat dui pharetra quis. Nunc a lacus at dolor ultrices elementum nec sit amet nisl. Vestibulum ultrices venenatis lobortis. Sed auctor faucibus sapien, a accumsan sapien eleifend nec. Maecenas molestie eu lacus vitae lacinia. Aliquam id libero non nibh sodales bibendum. Sed molestie ligula ex, eu finibus nisi efficitur nec. Curabitur convallis enim ullamcorper condimentum fringilla. Maecenas et varius metus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Praesent blandit rutrum purus mollis suscipit. Aliquam risus mi, egestas ut risus sed, imperdiet pretium mi. Proin quis fringilla lectus.

//Sed rhoncus diam odio, sed maximus lectus aliquet non. Quisque tempus malesuada cursus. Duis consequat, metus nec aliquet auctor, eros lorem ultrices purus, vel convallis erat tellus ac libero. Maecenas consectetur nisi ut nisl ultrices fringilla. Donec mollis vitae lacus quis accumsan. Fusce vitae blandit mi. In auctor eros a ante auctor placerat. Sed tempor nisl sem, at hendrerit sem aliquam eget. Morbi placerat eget ante vitae rhoncus. Donec ac hendrerit leo. Donec sit amet erat erat. Morbi dictum justo eget volutpat vehicula. Pellentesque orci sapien, rutrum ac lectus eu, aliquam dictum magna. Fusce fermentum posuere augue ut malesuada.

//Curabitur et maximus libero, in euismod nibh. Etiam cursus, velit non elementum iaculis, velit sem ornare lacus, vitae ultricies nisl tellus sit amet ligula. Sed at nisl velit. Suspendisse vel blandit urna. Donec tristique et nisl id mattis. Maecenas ac congue magna. Suspendisse fringilla nec nunc ut rutrum. Donec vel diam vel neque tempus ultricies. Etiam dapibus, urna at malesuada cursus, arcu orci scelerisque mi, at tempus lorem lectus a augue. Donec tincidunt tortor odio, in eleifend orci pretium eu. Sed dui nibh, finibus sit amet accumsan fermentum, sollicitudin vitae turpis. Donec purus neque, rutrum elementum tortor a, lacinia condimentum risus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;

//Nunc odio felis, venenatis quis placerat vitae, vulputate at est. Vestibulum convallis tortor sit amet urna fermentum, sed ultrices nulla fermentum. In molestie mauris non luctus ultricies. Mauris nec ante fringilla, ornare ante id, volutpat magna. Donec dui elit, fermentum at egestas at, maximus eu libero. Morbi gravida tortor vel rutrum ultrices. Praesent tristique et urna id dignissim. Praesent non eros turpis. Vestibulum blandit odio at purus fermentum posuere. Mauris rutrum at erat quis placerat. Ut luctus feugiat luctus. Donec eget odio cursus, aliquet urna ac, condimentum odio.

//Pellentesque at scelerisque odio. Fusce leo purus, facilisis facilisis libero non, vulputate rhoncus elit. In commodo nunc fermentum ex tincidunt, id aliquam nisi consequat. Suspendisse efficitur a nulla id auctor. Nam tristique erat metus, vitae tristique risus tristique vestibulum. Proin eu erat non libero volutpat consequat. Donec elementum semper velit, eget gravida neque tincidunt sagittis. Nulla et auctor enim. Fusce hendrerit elit vel urna lacinia, et luctus augue sodales. Curabitur fringilla, lacus id suscipit volutpat, est sapien vehicula tellus, eu condimentum turpis leo sed metus. Fusce imperdiet eros finibus sodales aliquet. Vestibulum dapibus, erat in consectetur tincidunt, dui nibh dignissim elit, non tempor nisl est quis justo. Morbi venenatis lorem eu urna viverra, ac tempor ante euismod. Mauris accumsan, orci id aliquet malesuada, erat sem euismod felis, eget suscipit metus tellus id neque.

//Duis nunc purus, ornare tristique tincidunt ut, egestas at enim. Fusce elementum elementum erat, eget convallis ex maximus vitae. Fusce at consectetur nibh. Ut eleifend dolor vitae quam tempor, in blandit dolor varius. Etiam eget fringilla felis. In ut velit eget erat pulvinar dictum. Curabitur ornare metus augue, id condimentum arcu tincidunt ac. Suspendisse potenti. Praesent tempus mi id mauris fringilla, quis ultricies urna dignissim.

//Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sollicitudin vestibulum erat ac tempor. Proin suscipit, diam id rhoncus consectetur, dolor dolor ullamcorper arcu, id finibus odio elit vel tortor. Suspendisse hendrerit pretium nisi, et sollicitudin dui ullamcorper a. Cras eu fringilla quam. Pellentesque eu venenatis tellus. Etiam consequat tortor sit amet semper finibus. Vestibulum rhoncus nulla sit amet iaculis volutpat. In ullamcorper faucibus convallis. Vivamus pharetra faucibus metus ut convallis. Mauris dolor augue, dapibus id venenatis nec, porta id lacus.

//Duis dignissim dignissim nisl at congue. Maecenas nec placerat lorem, non ultrices neque. Praesent sem elit, pretium nec tempus nec, malesuada a eros. Aenean sagittis diam sit amet magna vulputate lobortis. In aliquet lacus nec aliquet volutpat. Pellentesque mauris sapien, gravida quis porttitor quis, elementum id lorem. Sed eget semper justo.

//Aliquam erat volutpat. Donec ut erat nec neque maximus rutrum. Ut commodo, lacus a placerat malesuada, massa velit tincidunt nulla, in lacinia sapien felis tempor lacus. Pellentesque id ipsum vel urna hendrerit vehicula. Aenean pharetra euismod placerat. Cras tellus tortor, sagittis sit amet rhoncus id, blandit at libero. Integer pulvinar elit convallis auctor gravida. Quisque lobortis vehicula ligula tempus blandit. Praesent at tristique leo. Sed ut rhoncus sapien. Aliquam non faucibus dui. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Etiam efficitur, est id porta accumsan, lacus sem lobortis leo, a blandit ex dui ac purus. Sed nec pharetra odio, vel viverra magna. Quisque urna nulla, faucibus a ex ut, rutrum consectetur orci.

//Ut at elit mauris. Nullam tristique lacus vitae mi auctor mollis. Duis purus nulla, congue ac sollicitudin ut, mattis id diam. Sed sed mi porta turpis tincidunt placerat. Nulla venenatis sapien vitae tempor sodales. Sed lobortis odio est, eget pulvinar enim convallis ac. Aliquam eu erat nibh. Cras a dapibus justo.

//Aliquam id libero lacinia, porta augue eget, efficitur turpis. Pellentesque tempus id augue id aliquet. In ut lorem tempor, auctor odio nec, molestie lacus. Curabitur fringilla ac eros sed eleifend. Fusce dictum pharetra augue, sit amet tincidunt metus maximus sit amet. Vivamus finibus gravida lacus, et ultricies lorem congue id. Mauris vel nunc id purus porttitor ultricies. Proin ultrices, est quis consectetur consequat, dui felis laoreet justo, in venenatis elit justo et lectus. Aliquam sagittis lacus quis sodales malesuada. Vivamus mattis ac justo in bibendum. Ut in feugiat mauris, id congue nisl. Fusce posuere vestibulum elit, in dictum nibh venenatis ut.

//Nullam at blandit purus. Etiam et ullamcorper sem. Proin id ultricies massa, sed mattis diam. Cras et pellentesque nibh, nec convallis sapien. Proin turpis magna, maximus vitae metus consectetur, egestas rhoncus orci. Donec mattis enim eget nunc varius, ut luctus nibh rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Nullam non elit dolor. Nunc sit amet nulla sollicitudin, semper diam eget, euismod libero. Phasellus dignissim faucibus diam, a sollicitudin ligula pellentesque eget. Aliquam erat volutpat.

//Integer sem ante, congue id massa et, egestas maximus arcu. Nullam auctor sem velit, commodo molestie ipsum suscipit non. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Ut nec lectus et nunc finibus hendrerit. Cras enim sem, pellentesque in turpis lobortis, accumsan porttitor nisl. Ut sapien enim, commodo ac rhoncus a, pellentesque ut magna. Nunc ullamcorper auctor dui, ut fermentum metus scelerisque in. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla dictum efficitur ipsum et venenatis. Maecenas sit amet velit ac sem vehicula blandit. Nulla sollicitudin, quam vel commodo auctor, ante augue tempus odio, nec facilisis diam ex et libero. Quisque condimentum porttitor enim, et efficitur velit condimentum sed. Aenean eleifend risus et posuere auctor.

//Curabitur id luctus sem. Sed pharetra ut neque at luctus. Fusce eu semper nibh. Duis finibus nunc eu magna congue, non fermentum orci feugiat. Pellentesque velit orci, porttitor eu euismod nec, cursus accumsan lacus. Maecenas aliquam ac massa ut aliquam. Pellentesque tempus ornare tortor vel pretium. Nunc dictum molestie urna, et dignissim magna. Vivamus pretium magna non diam aliquet, ac mattis sem tincidunt. Fusce in ex pellentesque, interdum quam ut, faucibus velit. Morbi enim nunc, molestie ac ultrices vel, finibus sed augue. Fusce dignissim quis massa vitae malesuada. Suspendisse nec fringilla nibh, sit amet efficitur sem. Proin felis risus, faucibus ac vestibulum vitae, cursus at felis. Sed fringilla sollicitudin diam nec varius.

//Duis fringilla quam augue, sit amet mollis eros finibus a. Pellentesque euismod massa quis finibus ultricies. Quisque dapibus elit a risus imperdiet, et faucibus orci pellentesque. Suspendisse vitae venenatis nisl. Etiam libero ligula, pulvinar sed tellus ut, cursus viverra justo. Ut sit amet nisi eu odio ornare consequat eget sit amet libero. Vivamus dictum sapien ut justo posuere, id lobortis metus efficitur. Sed nec vulputate arcu. Integer eu purus tortor. Sed ac vulputate lorem. Vivamus sed libero ut ipsum rutrum semper efficitur ut nisl. Ut libero mi, tempus a purus eu, varius semper justo. Phasellus posuere hendrerit velit sit amet facilisis. Nulla quis urna ac felis bibendum fringilla ut ut nibh.

//Maecenas a dui id enim pharetra dictum in quis tellus. Aenean maximus luctus lacus vitae auctor. Etiam eu turpis enim. Proin molestie condimentum lacus, id convallis ex maximus eget. In diam lectus, rhoncus ac mi at, suscipit elementum eros. In ut nisi eget nunc malesuada venenatis at a ligula. Maecenas ipsum metus, finibus ac nulla sit amet, accumsan gravida erat. Quisque tempus est eu nulla aliquet accumsan. Nullam laoreet, diam in posuere consequat, dolor diam blandit lorem, quis faucibus nisi sem at nulla. Morbi eu venenatis magna, at tincidunt lorem. Cras nisi elit, posuere nec ligula sed, bibendum tempor lacus. Mauris vestibulum, dolor ac lobortis vestibulum, diam tellus volutpat urna, ac maximus nulla risus fringilla libero. Quisque viverra molestie diam, ut tempus mauris tristique iaculis.

//Duis tristique nibh ante, at laoreet eros laoreet nec. Aliquam congue aliquam interdum. Nullam a felis ligula. Quisque iaculis enim non tortor pharetra tincidunt. Praesent rutrum sagittis odio in malesuada. Nulla vel accumsan lacus, vitae bibendum enim. Praesent quis augue sit amet mi varius porta. Maecenas at libero rutrum, egestas lorem et, porta orci. Vivamus iaculis pretium lacus, eu ullamcorper nisl ultricies quis. Suspendisse potenti. Mauris consequat ante ultricies sapien elementum hendrerit. In elementum scelerisque felis sed porta. Cras viverra nisi ex, sit amet finibus mi facilisis sit amet. Suspendisse vehicula placerat nulla.

//Aliquam ultricies finibus risus, in egestas lorem volutpat scelerisque. Nulla dapibus purus metus, non hendrerit massa condimentum eget. Integer in convallis mauris. Praesent placerat suscipit consequat. Duis sed pharetra ligula. Morbi in arcu a ex semper ornare sit amet ut dui. Maecenas imperdiet, nisi ut faucibus dignissim, nisl arcu porta lectus, eget tincidunt ipsum lorem a ipsum. Vestibulum risus nisl, pretium vel neque id, eleifend varius nunc.

//Quisque egestas sagittis enim eget lobortis. In vulputate efficitur erat nec semper. Vestibulum massa augue, mattis viverra faucibus ut, gravida sit amet metus. Nam sit amet risus est. Morbi fringilla felis eget posuere suscipit. Mauris quam nulla, vulputate quis ipsum vitae, lacinia ultricies elit. Suspendisse feugiat enim quis tortor congue cursus. Etiam ut lacus ac nunc convallis varius non vitae mauris. Nam euismod nulla sit amet libero gravida, ut consectetur nibh ultrices. Nunc ultrices ligula a mauris mollis, at aliquam felis maximus. Nam lacinia egestas sem id varius. Sed scelerisque vitae neque non laoreet. Nullam cursus venenatis dui, at scelerisque lorem ullamcorper nec. Morbi pulvinar lorem nec ex finibus ultrices. Donec a diam ac odio rhoncus iaculis vel sed magna.

//Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aliquam rhoncus felis pellentesque, consectetur dolor quis, consequat est. Duis tempus eleifend elit et venenatis. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque eu euismod augue. Nam rhoncus mi in massa ornare dictum. Donec consectetur ex a massa tempor vehicula. Nunc eu egestas tortor.

//Cras sed mi sed nisl blandit molestie. Duis suscipit tortor orci, nec aliquam enim tincidunt at. Proin aliquam nisi nibh, sit amet molestie nunc dignissim quis. Duis quis convallis nibh, et pharetra neque. Duis eget lobortis orci. Nulla facilisis lectus eu sodales rutrum. Vivamus at risus in massa rhoncus dignissim. Nunc nisi ex, hendrerit id pretium nec, placerat ac justo.

//Etiam venenatis lectus ante, sed varius ex porta nec. Fusce diam orci, pulvinar eu suscipit egestas, dapibus non nisl. Vivamus faucibus eros quis libero elementum laoreet. Nulla facilisi. Aliquam aliquam elit vitae vulputate maximus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Phasellus porta neque sit amet tellus malesuada ullamcorper. Donec lacinia quis eros et ornare.

//Mauris ligula sem, scelerisque nec viverra id, tristique a quam. Sed sed felis ut felis imperdiet consectetur. Fusce in tempus purus. Nam ac tempor est. Donec vitae metus augue. Nunc ligula ligula, scelerisque ut feugiat a, interdum eu nunc. Donec fermentum eu massa ut porta. Duis tempor, dolor vel congue tempor, mi eros pretium lacus, eget dictum turpis sem luctus quam. Phasellus ac odio volutpat, vulputate magna in, pretium tortor. Nam porta est velit, nec hendrerit nisl commodo feugiat. Nulla ultricies augue nec tellus elementum, nec accumsan mauris dapibus. Proin lacus orci, dictum ut consectetur a, consequat et lectus.

//Pellentesque pretium, ex non tincidunt eleifend, nisi ipsum pulvinar felis, at lacinia nunc velit nec ligula. Donec tristique, diam at ultrices rhoncus, orci nunc dapibus nisi, eget pulvinar nisl sapien ut sapien. Proin dapibus egestas nunc, eu sodales diam varius vitae. Proin id mi non nunc dignissim mattis. Sed ultricies dui volutpat est lacinia semper. Ut id nunc et sem sodales vulputate non quis ex. Maecenas venenatis diam at nulla rutrum, vel interdum dui sollicitudin.

//Maecenas egestas nunc quis facilisis efficitur. In auctor, nibh sed suscipit eleifend, est justo commodo metus, at volutpat neque justo vel risus. Fusce commodo pretium posuere. Vivamus blandit, turpis quis elementum vehicula, risus nulla porttitor lorem, non tempus ipsum felis vel nunc. Vivamus congue dictum est quis maximus. Proin ornare a quam eget dictum. Nam eu vehicula felis. Curabitur dictum consequat scelerisque. Vestibulum eget tempor magna, in faucibus est. Nulla porta malesuada mauris et bibendum. Praesent in lorem finibus odio aliquet semper. Suspendisse in pharetra risus, a volutpat mi. Etiam tempor felis a velit molestie imperdiet nec quis mi. Sed in sapien nisl. Mauris tempor nunc lacus, vitae consectetur mauris efficitur ac.

//Mauris vulputate non erat vel semper. Nulla malesuada, erat in efficitur laoreet, enim velit tincidunt orci, nec euismod tellus ex sit amet tellus. Nam at tellus magna. In hac habitasse platea dictumst. Suspendisse potenti. Fusce bibendum elit vitae lorem venenatis facilisis. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Ut tincidunt dignissim dapibus. In luctus odio non finibus tincidunt. Aenean libero ipsum, tristique posuere metus at, pharetra eleifend nisi. Nunc nulla lectus, blandit eget urna eu, vulputate maximus leo. Donec finibus ex dui, nec imperdiet nisi consectetur eget.

//Duis enim ex, mollis vitae ligula quis, congue condimentum mauris. Proin ex sem, mattis eu pretium sed, mattis eu nisl. Nam porta risus felis, id iaculis arcu efficitur porttitor. Aliquam sit amet justo ante. Ut ornare rhoncus tortor, a luctus ante aliquam a. Fusce at metus nec diam pharetra facilisis ac eget tellus. In id urna urna. Morbi pellentesque blandit consequat. Mauris a enim consequat, porta eros ac, dapibus eros. Maecenas rutrum nisi eros, at elementum diam hendrerit a. Maecenas a libero risus. Ut non dictum purus. Morbi vehicula ac ex a ullamcorper.

//Duis varius sapien ac enim condimentum, at euismod nibh accumsan. Aenean consequat velit sed ligula tristique, id sollicitudin nulla consequat. Integer euismod, ante ac ullamcorper finibus, purus elit hendrerit orci, et commodo arcu massa eget felis. Morbi fringilla pellentesque iaculis. Vestibulum semper nisl sed ipsum tempus feugiat. Fusce vehicula quis velit at tincidunt. Nunc ornare quis mi id efficitur. Proin mollis lectus auctor metus sollicitudin, sit amet faucibus mauris blandit. Ut pharetra, neque et fringilla congue, magna odio elementum nisi, non ullamcorper purus turpis condimentum ligula. Donec vel mauris risus. Morbi non odio sed justo lobortis ultrices eu et tellus. Donec blandit pharetra metus vel tincidunt.

//Nunc justo nibh, vestibulum vel pretium at, commodo vitae ipsum. Aenean id suscipit augue. In consequat eros vitae imperdiet convallis. Duis a lacinia lacus. Nullam pretium nec nisl at feugiat. Praesent pharetra vulputate libero, sed tincidunt lacus commodo a. Donec fringilla consequat iaculis.

//Morbi tempus velit et erat dapibus vehicula ut in nisl. Mauris et orci non libero blandit rhoncus ut nec ipsum. Curabitur eget porta est. Aenean ut lacinia dui. Vivamus tincidunt ipsum ut nisl varius, et pretium velit pretium. Etiam ut metus eget augue convallis posuere ut vel urna. Sed sed nunc in eros tristique ullamcorper. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.

//Fusce lorem massa, fringilla ac ultricies id, condimentum ut risus. Vestibulum porttitor tellus mi, at tempor quam scelerisque non. Ut elementum nunc libero, ut maximus risus mattis ut. Quisque interdum est dolor, eget rhoncus nunc tincidunt quis. Suspendisse quis imperdiet massa, vel ultricies diam. Mauris ut quam pretium, elementum augue ac, tempor massa. Ut id hendrerit ligula. Cras hendrerit tempor eros, eu rutrum orci accumsan vitae. Sed posuere fermentum commodo. Integer vel lectus non lacus interdum sollicitudin et nec orci. Etiam tellus lorem, faucibus quis viverra id, ultricies a libero. Vestibulum finibus tellus nisl, quis luctus urna rhoncus nec. Etiam quis lectus eu sapien maximus rutrum. Maecenas pulvinar quis eros vel euismod. Phasellus libero dui, placerat eget varius vitae, vestibulum nec nibh. Integer efficitur nulla ante, ac sollicitudin ante efficitur in.

//Nunc diam nisi, semper sed nisi vel, blandit interdum risus. Sed et molestie ligula, in tincidunt nulla. Sed quis sapien enim. Quisque a sollicitudin libero. Integer neque arcu, lacinia ut ipsum ac, gravida aliquam purus. Vestibulum dignissim vel ligula eget fermentum. Donec tempus rutrum felis, non fermentum tellus luctus id. Sed eu elementum est, non pulvinar est. Etiam dui diam, convallis vel condimentum in, venenatis nec nisi. Vivamus dignissim ullamcorper ipsum, quis sollicitudin dolor eleifend bibendum. Vivamus semper, lacus et consequat tristique, lorem diam efficitur enim, ut tempor diam mi quis enim. Vestibulum sed massa suscipit, placerat sapien quis, volutpat justo. Phasellus consequat ex justo, nec imperdiet sapien volutpat ac.

//Etiam commodo risus sed justo consequat ornare. Praesent venenatis eu orci ut viverra. Fusce metus tellus, mollis eget felis at, aliquam tempus sem. In ultricies suscipit purus, in convallis augue pharetra quis. Aliquam tincidunt eros efficitur nunc consequat, ut commodo ipsum suscipit. Nunc vulputate feugiat efficitur. Quisque luctus luctus neque, at pulvinar enim scelerisque nec. Phasellus aliquam quis libero sed congue. Fusce laoreet justo congue mi sollicitudin, sit amet mattis nulla iaculis. Duis condimentum volutpat augue eu sodales. Aliquam maximus consequat dui eget finibus. Aliquam accumsan tempor eros ac egestas. Cras quis tincidunt tellus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Duis suscipit porttitor velit, eu aliquam sem molestie ac. Pellentesque sed tincidunt tortor.

//Phasellus sollicitudin vulputate scelerisque. Nunc orci sapien, sagittis vel ultricies nec, rhoncus eu nunc. Morbi viverra diam a lorem fermentum egestas. Nulla sollicitudin efficitur orci, quis blandit lorem blandit quis. Etiam finibus odio dolor, a molestie odio pellentesque id. Suspendisse sed nisl eget risus tempus tristique. Phasellus interdum aliquet purus, a ultricies magna posuere ut. Vestibulum lobortis enim tortor, sed egestas arcu volutpat et. In maximus velit a metus luctus, ut malesuada quam ultricies. Donec elit massa, pellentesque vitae volutpat rhoncus, semper quis neque. Praesent volutpat iaculis arcu eu mattis. Donec sed sem augue. Morbi ultrices auctor rutrum.

//Etiam sagittis, lorem vitae sagittis porta, ipsum augue dapibus felis, non ultrices sem lacus eu massa. Integer scelerisque libero at velit finibus pellentesque. Nulla vehicula porta libero, at suscipit leo laoreet sit amet. Praesent efficitur nisi lectus, vel semper neque laoreet at. Suspendisse varius, erat eu ultricies scelerisque, sem metus accumsan tortor, non mollis leo mauris ut dui. Praesent sagittis lacinia dolor, quis tempor est vehicula a. Nam ac tortor mauris. Phasellus quis leo gravida, commodo magna non, bibendum libero.

//Suspendisse iaculis viverra est, in scelerisque tellus consequat vel. In id est sed quam consequat dapibus ut a purus. Ut sit amet egestas orci, non accumsan nunc. Suspendisse tincidunt dolor ac tellus elementum suscipit. Aenean tincidunt in sapien vel lobortis. Curabitur mollis urna massa, at vulputate ex consectetur non. Nulla facilisis enim sit amet lectus volutpat, in sagittis arcu sollicitudin. Nullam placerat semper libero, eu tempus ligula hendrerit quis. Curabitur diam risus, venenatis id vestibulum nec, iaculis eu tortor. Donec vel cursus elit. Cras suscipit enim sed massa ornare, at ultrices justo ornare. Suspendisse vehicula mi id pellentesque lobortis. Donec ut malesuada erat, eget iaculis leo. Sed lacinia lorem ligula, nec ultricies eros facilisis a. Praesent id ipsum dolor. Nunc eu eleifend dolor.

//Fusce eget egestas leo. Maecenas dictum lacus eget imperdiet vestibulum. Donec id sapien id nunc sollicitudin commodo in vitae ligula. Donec varius mi dui, non aliquam ante ultricies luctus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce lorem mauris, egestas at velit ut, dictum porttitor sem. Praesent rutrum, erat eget efficitur vehicula, odio lacus ultricies turpis, quis ultricies enim ligula eget erat. Quisque tempus nibh egestas odio vulputate auctor. Praesent quis convallis lectus. Nulla facilisi. Nulla accumsan lobortis augue id volutpat. Integer elementum augue non quam dictum, vitae pretium nibh consectetur.

//Cras ut nisi turpis. Fusce mattis neque metus, sed imperdiet enim feugiat et. Fusce semper porttitor leo eget ultricies. Vivamus accumsan nisi non magna tincidunt facilisis. Aliquam in augue auctor, laoreet dolor eu, suscipit nisi. Nam sit amet sapien bibendum, dignissim diam sit amet, feugiat tellus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;

//Nullam aliquet ligula eget dictum vulputate. Maecenas eget augue non tortor feugiat porta. Praesent gravida faucibus imperdiet. Aliquam erat volutpat. Vivamus sed orci tristique, volutpat dolor placerat, cursus nibh. Nam efficitur risus id velit porta rhoncus. In non lorem tempor ex pulvinar lacinia. Etiam ac eros mollis, semper felis efficitur, ullamcorper lectus.

//Suspendisse potenti. Suspendisse sagittis lorem sit amet erat tincidunt posuere. Nullam aliquam commodo massa, ac molestie erat venenatis vitae. Donec vel lorem vitae turpis fermentum laoreet. In venenatis eros eu gravida tempus. Vestibulum consequat risus porta convallis lobortis. Duis luctus dui ac mattis eleifend.

//Quisque pretium mauris sed fringilla gravida. Aliquam orci velit, bibendum eu mi facilisis, consectetur tristique metus. Integer gravida diam non odio varius, ut pellentesque tellus mollis. Duis dictum risus diam, ac volutpat urna eleifend porta. Aenean eget magna ac arcu ornare maximus sit amet vitae odio. Maecenas et fringilla leo, nec lacinia justo. Phasellus commodo nec leo sed commodo. Proin scelerisque orci a metus blandit efficitur. Sed et tellus at augue lacinia viverra. Sed vel nunc massa. In velit lectus, cursus id metus vel, lacinia porttitor ligula. Mauris sed posuere lacus.

//Sed quis ultricies neque. Integer suscipit sapien et dui iaculis faucibus ac a purus. Morbi laoreet vel quam vel ullamcorper. Vivamus commodo leo lectus, eu tincidunt nibh fringilla in. Pellentesque in mauris sit amet enim blandit placerat. Donec convallis nunc vitae nibh blandit, ac faucibus lectus facilisis. Sed venenatis interdum sapien eget sagittis. Morbi at neque eu erat viverra suscipit eu et urna. Nunc tristique porttitor turpis quis vestibulum. Curabitur eget rutrum nisl, id posuere orci. Vivamus pharetra ex non molestie congue. Maecenas dapibus laoreet eros eu porttitor.

//Vestibulum eget mauris dapibus, cursus mi pellentesque, placerat dui. Nullam at metus aliquet, aliquam elit vitae, efficitur justo. Cras vitae viverra dolor. Suspendisse erat tellus, dictum eget felis sit amet, malesuada lacinia odio. Praesent nec tempor neque. Donec pellentesque magna ante, et gravida diam interdum sit amet. In mollis consectetur aliquet. Morbi venenatis convallis libero quis iaculis. In interdum, nunc in eleifend pharetra, elit ligula cursus nulla, sed tempor nisl nulla ut nisl. Proin varius metus magna, eu eleifend mauris facilisis sit amet.

//Duis condimentum nisi risus, sed fringilla lectus finibus non. Mauris commodo ligula non elit lacinia, sit amet luctus justo laoreet. In id purus aliquam, bibendum urna quis, auctor dolor. Quisque nec bibendum orci. Morbi eget elementum felis, at consectetur arcu. Nulla facilisi. Nullam malesuada sem a urna commodo congue. Curabitur quis tortor at tellus ornare tincidunt non vel lacus. Aenean in tincidunt quam.

//Fusce ullamcorper metus ut tempus ultrices. Mauris accumsan sagittis dolor, quis lobortis eros venenatis eu. Nam quis accumsan leo. Nullam in leo fringilla, dapibus enim quis, iaculis lorem. Fusce laoreet, mauris vitae porttitor tincidunt, lectus nunc commodo ante, vitae vulputate arcu elit eget quam. Morbi tincidunt odio ac nulla commodo, a placerat lectus molestie. Duis ullamcorper dolor id sagittis egestas. Quisque sed ante nec risus sagittis ultricies a ac nunc. Curabitur cursus ante nec aliquam mollis. Phasellus non imperdiet mauris. Cras et lectus at enim feugiat mollis et sit amet metus. Sed semper lobortis nisl, et porta magna tincidunt quis. Integer pharetra nisl et volutpat mollis. Integer quis odio nulla. Duis accumsan augue eget dui posuere, ac faucibus mi mollis.

//Morbi faucibus bibendum ipsum, eu interdum mi sodales vitae. Donec non dignissim est. Morbi consectetur leo purus, in pharetra sapien cursus vel. Cras eget venenatis erat. Maecenas vestibulum, tellus non hendrerit tempus, eros tellus rutrum arcu, et venenatis lacus nisi ut velit. Donec eu fermentum nulla. In ac ligula odio. In vehicula lectus semper condimentum sodales. Sed vitae scelerisque mi. Quisque eget magna ligula. Ut elementum ornare dolor, vel convallis justo mollis in. Etiam non diam eu magna accumsan condimentum quis sit amet metus. Mauris felis ligula, mattis sit amet dui vitae, hendrerit consequat nunc.

//Phasellus bibendum velit sem, quis sagittis felis luctus vitae. Cras tincidunt malesuada ipsum a egestas. Vestibulum gravida tincidunt justo, sed pulvinar velit venenatis mattis. Aliquam nec neque eleifend, dignissim turpis sed, pulvinar mauris. Curabitur sed velit pellentesque, sollicitudin mauris ac, semper velit. Curabitur mollis, sapien non ullamcorper suscipit, tortor nunc viverra lacus, in faucibus ex lorem ut lacus. Donec consequat dignissim nisl et sagittis. Nunc in lectus at dui mollis dignissim nec et quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.

//Praesent turpis mi, rhoncus non congue sed, aliquam vel nibh. Curabitur libero neque, commodo sed tortor sed, bibendum pulvinar est. Vivamus maximus, leo non rhoncus vehicula, velit nisi imperdiet neque, quis facilisis magna justo in nulla. Aenean faucibus magna nec mauris dapibus eleifend. Morbi lorem purus, euismod at libero in, lobortis elementum mi. Phasellus porttitor rutrum ligula, vitae cursus eros faucibus at. Aenean a lacus tortor. Fusce ac justo felis. Praesent at consectetur libero. Morbi vitae ante mollis, tristique nulla ac, aliquam mauris. Vivamus porttitor ex quis massa tempor fringilla.

//Aenean ornare urna mi, ut bibendum sapien mattis non. Fusce vel vulputate leo, sit amet tempor dui. Suspendisse condimentum pretium mi, nec euismod dolor faucibus ac. Sed egestas diam eu nisl maximus, sit amet finibus nunc mollis. Duis maximus neque ex, a elementum magna tristique eget. Sed efficitur ligula id elementum ornare. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aliquam lacinia turpis quis ligula egestas, a tincidunt lacus feugiat. Praesent sodales ante sem, eu volutpat urna hendrerit nec. In vel convallis ipsum, sed mollis orci. Vestibulum mattis elementum sem, et suscipit mi consectetur eget.

//Maecenas ac venenatis nisl. Sed dapibus efficitur est, non sollicitudin quam gravida sed. Nam at elit sit amet ligula luctus iaculis. Vestibulum urna mi, molestie quis hendrerit vel, vulputate ut nisl. In egestas efficitur aliquet. In semper porta hendrerit. Vestibulum malesuada diam in ligula fringilla, non suscipit quam dictum.

//Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nullam tincidunt eu arcu sit amet fringilla. Aenean scelerisque nunc commodo urna fermentum, quis lobortis lorem iaculis. Mauris semper ipsum a nisl lacinia fermentum. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Curabitur molestie massa non magna euismod varius. Aenean placerat velit sem, ut malesuada turpis facilisis ac. Praesent nisi lectus, aliquet at bibendum a, fermentum ut est. Interdum et malesuada fames ac ante ipsum primis in faucibus. Ut semper, augue quis sodales porttitor, purus dui maximus eros, auctor auctor eros leo sed sapien. Aenean non pellentesque dolor. Maecenas efficitur tortor a varius congue. Suspendisse hendrerit eget sapien eget lacinia. Donec posuere et dolor gravida tristique. Integer quis velit et nulla consectetur gravida id nec mi. Mauris nibh libero, vestibulum ut ullamcorper non, faucibus ac nisi.

//Curabitur mattis, velit eu varius gravida, risus nisl eleifend ex, ut porttitor ex turpis et nisi. Vivamus accumsan mollis justo, et pretium urna rhoncus eget. Nunc dapibus lorem et ornare ullamcorper. Mauris vehicula augue mauris. Suspendisse ac accumsan dui. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc iaculis tincidunt placerat. Aenean tellus dui, posuere elementum ultricies vel, tincidunt ac neque. Nulla ut mauris lobortis nisi maximus suscipit sed faucibus ex. Curabitur placerat leo sed sagittis faucibus.

//Nunc pretium, enim quis porta pretium, turpis turpis mollis nisl, vel viverra nisl tortor quis urna. Mauris accumsan dapibus ante, id ornare lacus hendrerit mollis. Vestibulum nisl nibh, pellentesque in consequat non, accumsan sit amet ligula. Proin vestibulum erat at enim lacinia, quis egestas turpis lacinia. Donec accumsan lectus vitae ipsum ullamcorper, a eleifend nibh sollicitudin. Ut dictum est sem, sed semper dolor egestas eu. Vivamus sed dolor molestie eros gravida imperdiet. Integer fermentum ultrices urna vitae consequat. Nulla in enim blandit, posuere lectus volutpat, gravida dolor.

//Quisque volutpat porttitor sem, vel mollis ante maximus sed. In sed finibus quam. Fusce pellentesque mi a mollis euismod. Fusce non commodo orci, id bibendum mi. Integer sodales maximus gravida. Proin sollicitudin in arcu et semper. Integer iaculis malesuada tellus, vel vestibulum neque varius quis. Duis sollicitudin arcu et nisi dapibus, a aliquam erat aliquet. Cras sapien enim, pretium id velit sed, convallis pellentesque lacus. Curabitur gravida libero tempus purus malesuada pellentesque id sit amet velit. Nulla facilisi. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Quisque elit erat, rutrum eget sagittis nec, tincidunt ut quam.

//Praesent et lorem tellus. Curabitur eu tellus maximus, imperdiet nunc eu, gravida quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Integer a eros nec lectus feugiat ultrices nec vulputate massa. Duis luctus nibh lectus, a elementum nulla commodo sit amet. Donec malesuada tempus arcu semper vestibulum. Phasellus lacinia, lectus eu lobortis vulputate, velit quam sagittis libero, sed sagittis urna sapien ac nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Suspendisse in lorem et ante facilisis egestas. Curabitur tincidunt enim sit amet massa cursus, eu laoreet sapien aliquet. Nulla pellentesque sapien quis viverra finibus.

//Etiam quis commodo dui. Suspendisse sit amet maximus massa, ut laoreet augue. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aenean tincidunt malesuada enim nec feugiat. Ut id tincidunt metus. Nullam eget nisl vehicula, pulvinar ipsum et, luctus erat. Praesent egestas, magna nec rhoncus vehicula, nisi nisl euismod elit, non feugiat nisl purus non justo. Nulla pharetra, tortor at suscipit pharetra, diam enim rutrum ex, ac efficitur nulla nunc eget odio. Aliquam ultricies erat ac sem laoreet, a vulputate nisl congue. Morbi nec fringilla nisi, eu egestas ipsum. Nullam tempor erat a maximus ultrices. Aliquam ornare, nibh vitae pellentesque tempus, urna diam placerat massa, eu pellentesque dolor sem sit amet lorem. Nunc et gravida mauris, sit amet mattis lacus. Sed iaculis, lorem ut placerat feugiat, sem enim placerat magna, eu accumsan risus augue eu felis. Nam ligula ex, eleifend sit amet laoreet sit amet, malesuada et ipsum. Proin id libero eu arcu auctor blandit.

//Maecenas ultricies, enim ac tempus blandit, mi neque congue ligula, et posuere est tortor ut arcu. Vestibulum sit amet sodales felis. Suspendisse pretium mi varius tellus tempor, a aliquam lacus efficitur. Duis pulvinar turpis sapien, sed laoreet ipsum vestibulum non. Nam non arcu ut dui eleifend aliquam vitae eu metus. Donec dapibus congue justo, nec hendrerit lacus bibendum in. Cras ultrices molestie enim a mollis.

//Proin vel metus condimentum, auctor urna vitae, pellentesque lectus. Ut blandit diam eu tellus pulvinar condimentum eu id felis. Curabitur tempor eros a tristique porta. Aenean at ex libero. Aliquam erat volutpat. Curabitur tempor ante nunc, in auctor tellus aliquam eu. Proin egestas turpis id venenatis fermentum. Nullam nec ligula et enim hendrerit pretium.

//Integer mollis nulla quis quam suscipit, aliquam mollis mi iaculis. Maecenas tristique odio diam, eu efficitur lorem euismod id. Nam fermentum tincidunt rhoncus. Donec viverra nec nisi at pretium. Donec aliquet quam quis ligula molestie, ut tincidunt dui feugiat. Sed nec elit quam. Sed est elit, ullamcorper nec eleifend nec, suscipit ut ligula.

//Quisque mi justo, volutpat ac libero accumsan, tristique auctor elit. Mauris sollicitudin lorem rutrum purus pellentesque rhoncus. Donec varius et nibh vel lacinia. Vestibulum volutpat, urna ac tristique tempor, tellus justo eleifend dui, aliquam ornare lacus diam nec ipsum. Pellentesque id tortor et erat eleifend ullamcorper. Sed consequat odio rutrum elit aliquet auctor. Ut sed viverra arcu.

//Suspendisse ornare, libero a pulvinar egestas, quam quam porttitor ex, ac faucibus velit erat at arcu. Pellentesque lobortis augue urna, sit amet euismod tellus aliquet id. Vivamus vel ipsum sapien. Aliquam erat volutpat. Vivamus posuere finibus sollicitudin. Vivamus sed nisi ornare, iaculis eros eu, condimentum sapien. Maecenas id neque viverra orci vehicula sollicitudin. Morbi varius, velit vel lobortis feugiat, nibh lorem imperdiet enim, sit amet lobortis sem dui vitae libero. In elementum neque ut tristique condimentum. Praesent pellentesque augue sapien, eu egestas arcu mollis quis. Sed nec elit pellentesque, vestibulum metus quis, cursus dolor.

//Aenean fringilla metus a neque aliquet, eget aliquam tortor suscipit. Nulla et consectetur risus. Donec eget lacus pharetra, interdum sapien ut, eleifend tellus. Cras non mauris quis odio dapibus tincidunt. Mauris tincidunt nunc sit amet scelerisque faucibus. Morbi sem lectus, varius id purus et, vestibulum pellentesque mi. Interdum et malesuada fames ac ante ipsum primis in faucibus. Phasellus efficitur eu lorem nec pretium. Suspendisse eleifend nisi ac pharetra lobortis. Etiam bibendum nisi vel lorem imperdiet vulputate.

//Proin vel elit id nibh auctor bibendum. Nunc nisi nisl, sodales in ultrices non, luctus sit amet sem. Praesent consectetur est et commodo facilisis. Etiam odio ligula, egestas pretium finibus sit amet, laoreet a ipsum. Maecenas auctor ultricies accumsan. Nunc porttitor et dui at suscipit. Phasellus a elementum lectus, ac dignissim leo.

//Suspendisse dignissim pharetra urna eget varius. Quisque aliquam interdum lectus posuere rutrum. Maecenas iaculis ante a erat condimentum accumsan. Ut vitae lectus in sapien efficitur convallis. Morbi lectus purus, auctor vitae mi vitae, lacinia tempus nisl. Morbi vestibulum, nisi vel dignissim venenatis, massa lectus faucibus nibh, at auctor urna est sed dui. In ultrices auctor porttitor. Nam et ipsum nulla. Donec sed egestas nisl. Mauris purus sem, rhoncus sed elit eu, tincidunt ornare mauris. In fringilla placerat enim vel faucibus.

//Pellentesque at ante sagittis, fermentum dolor in, fringilla enim. Proin consectetur sollicitudin enim eleifend condimentum. Nunc laoreet ipsum eget blandit pharetra. Cras sit amet velit orci. Interdum et malesuada fames ac ante ipsum primis in faucibus. Fusce dapibus ex sit amet lacus venenatis, ut imperdiet dui efficitur. Mauris viverra quam mi, vel tristique massa commodo ut. Nulla eget ipsum velit.

//Pellentesque suscipit arcu vitae lacus dictum, in accumsan sapien auctor. Integer rhoncus tellus at justo lobortis euismod. Phasellus luctus consectetur diam at luctus. Curabitur in sem sapien. Cras efficitur egestas enim in cursus. Quisque tempor venenatis odio, vel accumsan ex efficitur sed. In eget orci feugiat, efficitur ligula sed, laoreet nunc. Mauris euismod erat pharetra, dictum mauris non, vestibulum quam. Nullam pharetra enim vel nulla tincidunt, vitae lobortis elit interdum. Mauris porta mollis orci, ut condimentum odio facilisis nec. Maecenas non ornare magna, ac consectetur risus. Vivamus maximus lectus magna, nec accumsan mi suscipit nec. Maecenas nibh diam, pretium ac placerat at, efficitur ut eros.

//Curabitur accumsan eget eros eu aliquam. Praesent eu libero nibh. Nulla facilisi. Mauris et ante fermentum eros tempus imperdiet. Ut vulputate velit non mattis dignissim. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed blandit odio id eros bibendum scelerisque. Integer urna libero, scelerisque at ultricies at, posuere vel arcu. Nam id odio leo. Donec gravida, nulla et rhoncus consectetur, neque ante viverra nunc, nec pulvinar justo turpis sed massa. Suspendisse nec dui vestibulum elit tempor bibendum at vitae felis. Curabitur vehicula ullamcorper risus, eget congue urna lacinia laoreet. Praesent at cursus quam. Donec a elit a est euismod rutrum. Aliquam dapibus urna odio, sed porta arcu elementum sit amet.

//Donec in sollicitudin tortor, et suscipit nunc. In hac habitasse platea dictumst. Proin sit amet commodo odio. Maecenas vulputate nisi eget rhoncus euismod. Aenean et velit arcu. Sed non porttitor risus. Morbi tempus, sem ac feugiat consequat, lorem lorem faucibus ipsum, id ultrices lacus libero ut magna. Donec semper mi ornare, imperdiet ipsum quis, congue purus. Maecenas vestibulum dolor faucibus eros ullamcorper cursus ac in est.

//Ut ullamcorper dapibus bibendum. Donec vel sollicitudin ipsum. Vestibulum laoreet sit amet leo non eleifend. Quisque dignissim, dui non pharetra dictum, tellus erat malesuada sem, at tristique mi mi rhoncus ante. Curabitur vel placerat odio, et iaculis diam. Nulla efficitur leo vitae nunc egestas, ut consectetur lorem fringilla. Nam quis dignissim dui. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam iaculis nibh sed metus porta, sed pretium tortor pellentesque. Nunc porta sit amet nisi luctus faucibus. Praesent fermentum, nulla in dapibus luctus, ligula turpis iaculis velit, vitae aliquet magna purus eu erat. Donec ac urna congue, porta mauris sit amet, tincidunt leo. Donec imperdiet sollicitudin dui ac tristique.

//Praesent vehicula commodo libero id viverra. Morbi venenatis felis quis diam tincidunt tempor. In non dui metus. Maecenas blandit magna nec ex venenatis, sit amet lobortis justo lobortis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Donec dictum augue nisl, in semper ligula mattis eu. Nam mollis laoreet pulvinar. Sed turpis justo, pharetra a semper ut, scelerisque a lorem. Curabitur porttitor, sem vel mattis sodales, eros elit rutrum metus, vitae condimentum sapien nibh ut dui. Mauris fringilla diam sit amet risus volutpat, non ornare sem consequat. Maecenas quam diam, luctus ut fermentum vitae, sodales id metus.

//Maecenas odio lorem, auctor et odio in, eleifend blandit lectus. Integer et gravida massa, et faucibus enim. Vestibulum sollicitudin sit amet magna quis ultrices. Quisque ligula urna, fermentum quis erat iaculis, commodo vulputate velit. Sed in magna cursus, pulvinar orci et, molestie diam. Nulla eleifend quam vitae nulla congue suscipit. Phasellus neque eros, euismod in orci vitae, ultrices semper orci. Sed molestie elit eu libero varius consectetur. Nulla luctus scelerisque urna ac eleifend. Suspendisse sit amet neque vel justo vestibulum ornare. Fusce eleifend felis eu felis gravida porta.

//Aenean purus metus, luctus non molestie id, facilisis ac augue. Sed sed tempus nisi. Sed a malesuada enim. Aenean nisl neque, tempus ac varius a, aliquam a ipsum. Nullam pharetra risus nulla. Etiam quis ultricies mi. Nullam sit amet vehicula ex. Nullam mollis orci ipsum, vitae iaculis tellus tempor nec. Duis nisl metus, sodales tempus diam at, bibendum vestibulum neque.

//Nulla at sem interdum, tristique odio eget, elementum velit. Curabitur varius scelerisque quam quis aliquam. Aliquam dictum, nisl rutrum posuere aliquet, nulla odio consectetur nulla, sed convallis urna dui a justo. Quisque vulputate purus elementum, eleifend ante eu, malesuada eros. Phasellus ultricies dictum accumsan. Nulla iaculis metus nec nisl sagittis varius. Vivamus quis sodales urna. Phasellus fringilla ultrices pulvinar. Suspendisse varius nibh dolor, at aliquam risus ultrices vel.

//Ut euismod diam nec nisl vehicula sagittis. Morbi luctus, dolor sit amet faucibus commodo, mauris purus iaculis enim, vel gravida magna sem et augue. Integer lobortis scelerisque ultrices. Etiam dictum efficitur nibh, eu convallis dui rutrum vel. Quisque eu nunc eu eros molestie cursus in eu ex. Donec sit amet ex porttitor, cursus enim non, efficitur urna. Etiam hendrerit lectus metus, sit amet blandit augue luctus eget. Vivamus urna ligula, pulvinar at lacinia iaculis, congue et justo. Nullam sit amet odio at neque feugiat pretium vitae id purus. Morbi cursus, enim sed consequat mollis, nisl tellus accumsan est, vehicula tempus est risus nec nisi. Vestibulum quis lacus semper, lacinia enim eu, varius nibh. Nulla lacus eros, varius vitae consequat sit amet, placerat at justo.

//Duis viverra nisi et mauris ullamcorper pretium. Curabitur malesuada, felis ac vehicula bibendum, lacus erat ullamcorper mauris, vitae sodales ipsum dui nec justo. Nunc quis finibus risus. Sed sit amet nulla non ante rutrum pellentesque et ac sapien. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur eleifend vestibulum semper. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Maecenas ac erat iaculis, tempor nibh non, egestas lorem. Praesent interdum est sit amet ante blandit, ac rutrum nisi placerat. Vivamus consequat tincidunt ante. In ut turpis eget lorem pretium dapibus id id justo. Vivamus non bibendum ipsum. Praesent sagittis ac felis eu mattis. Phasellus venenatis tincidunt feugiat. Etiam egestas semper lobortis. Donec magna nisl, sagittis sit amet metus id, maximus efficitur mauris.

//Curabitur id magna nec metus vestibulum pretium. Integer facilisis nec nibh et lacinia. Cras vitae luctus nibh, nec lacinia mi. Nulla odio eros, euismod sit amet sagittis et, fringilla in sapien. Fusce dignissim nulla vitae efficitur commodo. Nulla ornare arcu ut mollis egestas. Donec ultrices id augue id rutrum. Quisque congue tortor nec sem eleifend, vel dignissim velit vehicula. Vivamus a sem ipsum. Nunc tempus congue nulla, eget consequat arcu mattis pharetra. In quis lorem et justo porta interdum.

//Curabitur ac elementum nunc, vitae iaculis eros. Aliquam posuere nibh ligula, eget eleifend erat accumsan sed. Suspendisse in malesuada odio. Integer non justo diam. Pellentesque quis gravida lorem. Cras feugiat, velit id aliquam sagittis, justo lacus aliquet nunc, in condimentum lectus dui id nulla. In ut mattis massa, in maximus mauris. Cras viverra dictum felis, sit amet pretium elit convallis tempor. Suspendisse efficitur, lacus quis rutrum ultricies, purus odio tincidunt diam, ac aliquam nulla mauris viverra sem. Pellentesque dapibus, leo eu pharetra lacinia, libero leo molestie risus, at semper odio nunc ut turpis. Morbi eget mauris consectetur dolor placerat tempor.

//Ut auctor accumsan felis, eu rutrum metus sollicitudin in. In ullamcorper volutpat ante, sed porttitor leo consectetur a. Donec accumsan mi quis nisi porttitor condimentum. Fusce porttitor mi nec sapien pulvinar, dignissim lacinia felis mattis. Maecenas auctor dapibus felis rhoncus fringilla. Nullam id leo dapibus, dictum orci eu, porttitor urna. Nunc pulvinar nunc iaculis porttitor vulputate. Aliquam finibus arcu vel lorem malesuada pellentesque. In efficitur nisl luctus, tincidunt risus non, tempor magna. Vestibulum sit amet odio sed libero venenatis mattis. Sed facilisis risus ac orci mollis congue.

//Sed at lacus purus. Nam suscipit neque quis arcu tristique, viverra tincidunt libero convallis. Vivamus iaculis diam purus, quis mattis erat rhoncus at. Quisque aliquam massa lacus, vitae ultricies tellus suscipit non. Morbi ultrices sodales mauris in rutrum. Phasellus eget felis hendrerit, porta dolor sit amet, ullamcorper velit. Phasellus congue urna non ipsum congue, sed tempor massa ultricies. Vestibulum metus nisl, lobortis ornare ante sed, efficitur lobortis sem. Morbi non leo et purus faucibus mollis quis sit amet magna. Sed sed augue consequat tortor hendrerit dignissim at ac magna. Proin blandit mi sed egestas facilisis. Ut faucibus libero lorem, non eleifend sem sodales in. Aenean sed nisl ac elit condimentum vestibulum. Suspendisse et sem lobortis, luctus eros eu, vehicula eros. Nulla tristique pretium ligula eu venenatis. Vestibulum rhoncus pharetra nisi vitae fermentum. Nam tempus semper.";

//            tb_text.Text += tb_text.Text + tb_text.Text + tb_text.Text + tb_text.Text + tb_text.Text;
//            btn_encrypt.Enabled = true;
        }

        private void methodChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if(rb == rb_method_decrypt)
            {
                mainForm.rb_method_decrypt.Checked = true;
                this.Close();
                mainForm.Show();
            }
        }

        private void encTypeChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if(rb == rb_encType_txtFile)
            {
                this.Close();
                this.mainForm.rb_encType_txtFile.Checked = true;
            }
            else if(rb == rb_encType_image)
            {
                this.Close();
                this.mainForm.rb_encType_image.Checked = true;
            }
            else return;
        }

        private void chooseFolder(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dialog = vistaFolderBrowserDialog1;
            dialog.Description = "Select a folder";
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                if (folderOkay)
                {
                    folderOkay = false;
                    ++requiredValues;
                    btn_encrypt.Enabled = false;

                }
                return;
            }
            if (!folderOkay)
            {
                folderOkay = true;
                if (--requiredValues == 0)
                    btn_encrypt.Enabled = true;
            }
        }

        private void textChanged(object sender, EventArgs e)
        {
            if(tb_text.Text.Length > 0)
            {
                if (!textOkay)
                {
                    textOkay = true;
                    if (--requiredValues == 0)
                        btn_encrypt.Enabled = true;
                }
            }
            else if (textOkay)
            {
                textOkay = false;
                requiredValues++;
                btn_encrypt.Enabled = false;
            }
        }

        private void encrypt(object sender, EventArgs e)
        {
            string key = tb_key.Text?.Trim();
            if(key.Length != faes.bytesForKey) //Key control
            {
                MessageBox.Show(
                    "Length of key must be " + faes.bytesForKey.ToString()+"!",
                    "Key is not valid!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                tb_key.Focus();
                return;
            }

            string folderPath = vistaFolderBrowserDialog1.SelectedPath?.Trim();
            if(String.IsNullOrEmpty(folderPath)) //Folder Control
            {
                MessageBox.Show(
                    "You must select the folder of the file where the encryption result will be saved.",
                    "No folder selected!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                btn_chooseFolder.Focus();
                return;
            }

            string filename = tb_filename.Text?.Trim();
            if (String.IsNullOrEmpty(filename)) //Filename Control
                filename = defaultEncryptedFileName;

            string text = tb_text.Text?.Trim();
            if(String.IsNullOrEmpty(text)) //Text Control
            {
                MessageBox.Show(
                    "You must enter a text that you want to be encrypted.",
                    "No text entered!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                tb_text.Focus();
                return;
            }

            string encrypted = "";
            try{

                Stopwatch sw = new Stopwatch();

                CancellationTokenSource source = new CancellationTokenSource();
                Task.Run(() =>
                { //Encryption part
                    sw.Start();
                    encrypted = faes.encryptText(text, key);
                    sw.Stop();
                }, source.Token);


                //Form
                ProcessForm pf = new ProcessForm();
                pf.Text = "ENCRYPTION PROCESS";
                pf.pbarText = "Encryption text";
                pf.lbl_imageSize.Visible = false;
                this.Hide();
                pf.Show();
                pf.Activate();
                pf.startProcess(
                    faes: this.faes,
                    sw: sw,
                    source: source,
                    Process.GetCurrentProcess(),
                    Finished: delegate ()
                    {
                        //Write a faes file
                        string filePath = Path.Combine(folderPath, filename + ".faes");
                        File.WriteAllText(filePath, encrypted);

                        //Open faes file with notepad
                        Process notepad = Process.Start(@"notepad.exe", filePath);

                        pf.FormClosed += (object oo, FormClosedEventArgs ee) =>
                        {
                            this.Close();
                            mainForm.rb_method_decrypt.Checked = true;
                            mainForm.rb_decType_txtFile.Checked = true;
                        };
                    }
                );
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "An error occurred when encrypt the text.\n\nError Message:\n" + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace,
                    "Encryption Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
        }
    }
}