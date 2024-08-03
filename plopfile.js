import path from 'path';
import { fileURLToPath } from 'url';

// تحويل __filename و __dirname لاستخدامها مع ES module
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

export default function (plop) {
    // قراءة المعلمات من argv
    const args = process.argv.slice(2);
    let name = '';
    let destPath = 'Controllers';

    args.forEach(arg => {
        if (arg.startsWith('--name=')) {
            name = arg.split('=')[1];
        }
        if (arg.startsWith('--path=')) {
            destPath = arg.split('=')[1];
        }
    });

    if (!name) {
        console.error('Kontrolör adı belirtilmemiş.');
        process.exit(1);
    }

    plop.setGenerator('c', {
        description: 'Yeni bir kontrolör dosyası oluştur',
        prompts: [],
        actions: [
            {
                type: 'add',
                path: path.resolve(__dirname, destPath, `${name}Controller.cs`),
                templateFile: path.resolve(__dirname, 'plop-templates/controller.hbs')
            }
        ]
    });
}
