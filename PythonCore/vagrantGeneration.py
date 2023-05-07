import os
import subprocess
import jinja2
import sys
import logging

logging.basicConfig(filename='app.log', filemode='a', format='%(asctime)s - %(message)s', level=logging.INFO)
logging.info('Script vagrantGeneration.py is running')

validOs = {"ubuntu/trusty64"}





def generate_vagrantfile(os_name, cpu_cores, memory):
    # Определяем шаблон Vagrantfile с помощью Jinja2
    print("Script vagrantGeneration.py is running")

    os_name_validated = validate_os(os_name)

    if os_name_validated is None:
        # Обработка невалидной операционной системы
        return None
    


    template = """
    Vagrant.configure("2") do |config|
        config.vm.box = "{{ os }}"
        config.vm.provider "virtualbox" do |vb|
            vb.memory = {{ memory }}
            vb.cpus = {{ cores }}
        end
    end
    """
    # Создаем шаблон и заполняем его параметрами
    vagrantfile = jinja2.Template(template).render(os=os_name, cores=cpu_cores, memory=memory)
    return vagrantfile

def main():
    # Параметры виртуальной машины
    os_name = "ubuntu/trusty64"
    cpu_cores = 2
    memory = 2048

    # Создаем директорию для проекта
    os.makedirs("my_vm", exist_ok=True)
    os.chdir("my_vm")

    # Генерируем и записываем Vagrantfile
    vagrantfile = generate_vagrantfile(os_name, cpu_cores, memory)

    if vagrantfile is None:
        return


    with open("Vagrantfile", "w") as f:
        f.write(vagrantfile)

    # Запускаем виртуальную машину с помощью Vagrant
    subprocess.run(["vagrant", "up"])

    # Выполняем команду внутри виртуальной машины
    subprocess.run(["vagrant", "ssh", "-c", "'echo \"Hello World\"'"])



def validate_os(os):
    supported_os = ["ubuntu/trusty64"]

    if os not in supported_os:
        return None
    
    return os


if __name__ == '__main__':
    main()


